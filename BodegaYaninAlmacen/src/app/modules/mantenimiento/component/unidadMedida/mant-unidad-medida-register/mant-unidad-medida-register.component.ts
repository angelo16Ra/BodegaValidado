import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MantUnidadMedidaListComponent } from '../mant-unidad-medida-list/mant-unidad-medida-list.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestUnidadMedida } from '../../../models/unidadMedida-request.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UnidadMedidaService } from '../../../service/unidad-medida.service';
import { convertToBoolean } from '../../../../../functions/general.functions';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { ResponseUnidadMedida } from '../../../models/unidadMedida-response.model';

@Component({
  selector: 'app-mant-unidad-medida-register',
  standalone: true,
  imports: [
    MantUnidadMedidaListComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-unidad-medida-register.component.html',
  styleUrl: './mant-unidad-medida-register.component.css'
})
export class MantUnidadMedidaRegisterComponent implements OnInit{


  
  /** TODO: DECLARANDO  VARIABLES DE ENTRADA */
  @Input() title:string = "";
  @Input() unidadMedida:RequestUnidadMedida = new  RequestUnidadMedida();
  @Input() accion:number = 0;


  /** TODO: DECLARANDO  VARIABLES DE SALIDA */
  @Output() closeModalEmmit = new EventEmitter<boolean>();
  

  /** TODO: DECLARANDO  VARIABLES INTERNAS */
  myForm:FormGroup;
  unidadMedidaEnvio:RequestUnidadMedida = new RequestUnidadMedida();


  /** TODO: DECLARANDO  EL CONSTRUNCTOR */

  constructor(
    private fb:FormBuilder,
    private _unidadMedidaService:UnidadMedidaService,
  ){
    //nuestro formulario rol request
    this.myForm= this.fb.group({

      codigoUnidadMedida: [{value:0,disabled: true},[Validators.required]],
      nombre:  [null,[Validators.required]],
      descripcion:  [null,[Validators.required]],
      estado: [null,[Validators.required]],
    });
  }




  ngOnInit(): void {

    console.log("title ==>", this.title);
    console.log("rol ==>", this.unidadMedida);

    this.myForm.patchValue(this.unidadMedida)


  }

  guardar()
  {

    this.unidadMedidaEnvio= this.myForm.getRawValue();

    this.unidadMedidaEnvio.estado = convertToBoolean(this.unidadMedidaEnvio.estado.toString());

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
    this._unidadMedidaService.create(this.unidadMedidaEnvio).subscribe({
      next:(data:ResponseUnidadMedida)=>{
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

    this._unidadMedidaService.update(this.unidadMedidaEnvio).subscribe({
      next:(data:ResponseUnidadMedida)=>{
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
