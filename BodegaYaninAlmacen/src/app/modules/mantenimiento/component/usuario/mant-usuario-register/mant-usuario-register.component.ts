import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SharedModule } from '../../../../shared/shared.module';
import { ResponsePersona } from '../../../models/persona-response.model';
import { ResponseRol } from '../../../models/rol-response.model';
import { RequestUsuario } from '../../../models/usuario-request.model';
import { Vusuario } from '../../../models/VUsuario.model';
import { UsuarioService } from '../../../service/usuario.service';
import { MantUsuarioListComponent } from '../mant-usuario-list/mant-usuario-list.component';

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
      codigoUsuario: [null,[Validators.required]],
      codigoRol: [null,[Validators.required]],
      codigoPersona: [null,[Validators.required]],
      userName: [null,[Validators.required]],
      password: [null,[Validators.required]],
      estado: [null,[Validators.required]],
      estadoDescripcion: [null,[Validators.required]],
      fechaRegistro: [null,[Validators.required]],
      fechaActualizar: [null,[Validators.required]],
    });
  }

  ngOnInit(): void {

    this.myForm.patchValue(this.usuario)


  }

  guardar()
  {


  }

  cerrarModal(res:boolean)
  {

    //true ==> hubo modificacion en base de datos  ==> necesito volver a cargar la lista
    //false ==> no hubo modificacion en base de datos  ==> no necesito volver a cargar la lista
    this.closeModalEmmit.emit(res);

    
  }


}
