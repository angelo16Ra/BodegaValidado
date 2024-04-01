import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output, output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { convertToBoolean } from '../../../../../functions/general.functions';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestRol } from '../../../models/rol-request.model';
import { ResponseRol } from '../../../models/rol-response.model';
import { RolService } from '../../../service/rol.service';
import { MantRolListComponent } from '../mant-rol-list/mant-rol-list.component';

@Component({
  selector: 'app-mant-rol-register',
  standalone: true,
  imports: [
    MantRolListComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-rol-register.component.html',
  styleUrl: './mant-rol-register.component.css'
})
export class MantRolRegisterComponent implements OnInit {
  

  /** TODO: DECLARANDO  VARIABLES DE ENTRADA */
  @Input() title:string = "";
  @Input() rol:RequestRol = new  RequestRol();
  @Input() accion:number = 0;


  /** TODO: DECLARANDO  VARIABLES DE SALIDA */
  @Output() closeModalEmmit = new EventEmitter<boolean>();
  

  /** TODO: DECLARANDO  VARIABLES INTERNAS */
  myForm:FormGroup;
  rolEnvio:RequestRol = new RequestRol();


  /** TODO: DECLARANDO  EL CONSTRUNCTOR */

  constructor(
    private fb:FormBuilder,
    private _rolService:RolService,
  ){
    //nuestro formulario rol request
    this.myForm= this.fb.group({

      codigoRol: [{value:0,disabled: true},[Validators.required]],
      nombre:  [null,[Validators.required]],
      descripcion:  [null,[Validators.required]],
      estado: [null,[Validators.required]],
    });
  }




  ngOnInit(): void {

    console.log("title ==>", this.title);
    console.log("rol ==>", this.rol);

    this.myForm.patchValue(this.rol)


  }

  guardar()
  {

    this.rolEnvio= this.myForm.getRawValue();

    this.rolEnvio.estado = convertToBoolean(this.rolEnvio.estado.toString());

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
    this._rolService.create(this.rolEnvio).subscribe({
      next:(data:ResponseRol)=>{
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

    this._rolService.update(this.rolEnvio).subscribe({
      next:(data:ResponseRol)=>{
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
