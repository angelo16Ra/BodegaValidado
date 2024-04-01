import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { convertToBoolean } from '../../../../../functions/general.functions';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestUsuario } from '../../../models/usuario-request.model';
import { ResponseUsuario } from '../../../models/usuario.response.model';
import { UsuarioService } from '../../../service/usuario.service';
import { MantUsuarioListComponent } from '../mant-usuario-list/mant-usuario-list.component';

@Component({
  selector: 'app-mant-usuario-register',
  standalone: true,
  imports: [
    MantUsuarioListComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-usuario-register.component.html',
  styleUrl: './mant-usuario-register.component.css'
})
export class MantUsuarioRegisterComponent implements OnInit {

  /** TODO: DECLARANDO  VARIABLES DE ENTRADA */
  @Input() title:string = "";
  @Input() usuario:RequestUsuario = new  RequestUsuario();
  @Input() accion:number = 0;


  /** TODO: DECLARANDO  VARIABLES DE SALIDA */
  @Output() closeModalEmmit = new EventEmitter<boolean>();
  

  /** TODO: DECLARANDO  VARIABLES INTERNAS */
  myForm:FormGroup;
  usuarioEnvio:RequestUsuario = new RequestUsuario();


  /** TODO: DECLARANDO  EL CONSTRUNCTOR */

  constructor(
    private fb:FormBuilder,
    private _usuarioService:UsuarioService,
  ){
    //nuestro formulario usuario request
    this.myForm= this.fb.group({

      codigoUsuario: [{value:0,disabled: true},[Validators.required]],
      codigoRol:  [{value:0,disabled: true},[Validators.required]],
      codigoPersona:  [{value:0,disabled: true},[Validators.required]],
      userName:  [null,[Validators.required]],
      password:  [null,[Validators.required]],
      estado: [null,[Validators.required]],
      fechaRegistro:  [null,[Validators.required]],
      fechaActualizar:  [null,[Validators.required]],

    });
  }


  ngOnInit(): void {
    this.myForm.patchValue(this.usuario)


  }

  guardar()
  {

    this.usuarioEnvio= this.myForm.getRawValue();

    this.usuarioEnvio.estado = convertToBoolean(this.usuarioEnvio.estado.toString());

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
        alert("creado de forma correcta")
      },
      error:()=>{
        alert("ocurrio un error la momento de crear")
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
        alert("actualizado de forma correcta")
      },
      error:()=>{
        alert("ocurrio un error la momento de actualizar")
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
