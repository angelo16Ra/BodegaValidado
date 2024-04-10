import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SharedModule } from '../../../../shared/shared.module';
import { UsuarioService } from '../../../service/usuario.service';
import { MantUsuarioListComponent } from '../mant-usuario-list/mant-usuario-list.component';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { alert_error, alert_success } from '../../../../../functions/general.functions';
import { Vusuario } from '../../../models/VUsuario.model';
import { ResponsePersona } from '../../../models/persona-response.model';
import { ResponseRol } from '../../../models/rol-response.model';
import { RequestUsuario } from '../../../models/usuario-request.model';
import { ResponseUsuario } from '../../../models/usuario.response.model';

@Component({
  selector: 'app-mant-usuario-register',
  standalone: true,
  imports: [
    MantUsuarioListComponent,
    CommonModule,
    SharedModule,
    ReactiveFormsModule
  ],
  templateUrl: './mant-usuario-register.component.html',
  styleUrl: './mant-usuario-register.component.css'
})
export class MantUsuarioRegisterComponent {

  @Input() title:string = "";
  @Input() usuario:Vusuario = new  Vusuario();
  @Input() accion:number = 0;
  @Input() tipoPersona:ResponsePersona[]=[];
  @Input() tipoRol:ResponseRol[]=[];
  
  @Output() closeModalEmmit = new EventEmitter<boolean>();
  
  myForm:FormGroup;
  usuarioEnvio:RequestUsuario = new RequestUsuario();


  constructor(
    private fb:FormBuilder,
    private _usuarioService:UsuarioService,
  ){
    //nuestro formulario rol request
    this.myForm= this.fb.group({
      codigoUsuario: [{ value: 0, disabled: true }, [Validators.required]],
      codigoRol: [null,[Validators.required]],
      codigoPersona: [null,[Validators.required]],
      userName: [null,[Validators.required]],
      password: [null,[Validators.required]],
      estado: [null,[Validators.required]],
      fechaRegistro: [null,[Validators.required]],
      fechaActualizar: [null,[Validators.required]],
    });
  }

  ngOnInit(): void {

    this.myForm.patchValue(this.usuario)


  }

  guardar()
  {
    this.usuarioEnvio= this.myForm.getRawValue();

    switch(this.accion){
      case AccionMantConst.crear: 
        // crear nuevo registro
        this.crearRegistro();
        break;
      case AccionMantConst.editar: 
        // inactivar 
        this.editarRegistro();
        break;
      case AccionMantConst.eliminar:  
       // eliminar registro  
        // en el formulario el eliminar no se implementa pero se pone el ejemplo para 
        //que la lectura de codigo sea mas sencillo
        break;
    }
  }

  crearRegistro()
  {
    //lamar a nuestro servicio rest ==> crear un nuevo registro en base de datos
    this._usuarioService.create(this.usuarioEnvio).subscribe({
      next:(data:ResponseUsuario)=>{
        console.log(data);
        alert_success("EXCELENTE","Se actualizo de manera correcta")
      },
      error:()=>{
        alert_error("ERROR","ocurrio un error la momento de añadir")
      },
      complete:()=>{
        this.cerrarModal(true);
      },
    });
  }

  editarRegistro()
  {

    this._usuarioService.update(this.usuarioEnvio).subscribe({
      next:(data:ResponseUsuario)=>{
        alert_success("EXCELENTE","Se actualizo de manera correcta")
      },
      error:()=>{
        alert_error("ERROR","ocurrio un error la momento de actualizar")
      },
      complete:()=>{
        this.cerrarModal(true);
      },
    });
  }



  cerrarModal(res:boolean)
  {

    //true ==> hubo modificacion en base de datos  ==> necesito volver a cargar la lista
    //false ==> no hubo modificacion en base de datos  ==> no necesito volver a cargar la lista
    this.closeModalEmmit.emit(res);

    
  }


}
