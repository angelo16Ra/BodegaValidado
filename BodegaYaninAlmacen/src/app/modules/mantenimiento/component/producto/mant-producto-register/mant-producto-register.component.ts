import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SharedModule } from '../../../../shared/shared.module';
import { ResponseAlmacene } from '../../../models/almacen-response.model';
import { ResponseCategoria } from '../../../models/categoria-response.model';
import { RequestProducto } from '../../../models/producto-request.model';
import { ResponseProveedor } from '../../../models/proveedor-response.model';
import { ResponseSubCategoria } from '../../../models/subCategoria-response.model';
import { ResponseUnidadMedida } from '../../../models/unidadMedida-response.model';
import { Vproducto } from '../../../models/VProducto.model';
import { ProductoService } from '../../../service/producto.service';
import { MantProductoListComponent } from '../mant-producto-list/mant-producto-list.component';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { ResponseProducto } from '../../../models/producto-response.model';
import { alert_error, alert_success } from '../../../../../functions/general.functions';

@Component({
  selector: 'app-mant-producto-register',
  standalone: true,
  imports: [
    MantProductoListComponent,
    CommonModule,
    SharedModule,
    ReactiveFormsModule
  ],
  templateUrl: './mant-producto-register.component.html',
  styleUrl: './mant-producto-register.component.css'
})
export class MantProductoRegisterComponent implements OnInit{
  @Input() title:string = "";
  @Input() producto:Vproducto = new  Vproducto();
  @Input() accion:number = 0;
  @Input() tipoUnidadMedida:ResponseUnidadMedida[]=[];
  @Input() tipoCategoria:ResponseCategoria[]=[];
  @Input() tipoSubCategoria:ResponseSubCategoria[]=[];
  @Input() tipoProveedor:ResponseProveedor[]=[];
  @Input() tipoAlmacen:ResponseAlmacene[]=[];


  /** TODO: DECLARANDO  VARIABLES DE SALIDA */
  @Output() closeModalEmmit = new EventEmitter<boolean>();
  

  /** TODO: DECLARANDO  VARIABLES INTERNAS */
  myForm:FormGroup;
  productoEnvio:RequestProducto = new RequestProducto();


  /** TODO: DECLARANDO  EL CONSTRUNCTOR */

  constructor(
    private fb:FormBuilder,
    private _productoService:ProductoService,
  ){
    //nuestro formulario rol request
    this.myForm= this.fb.group({
      codigoProducto:[{ value: 0, disabled: true }, [Validators.required]],
      codigoUnidadMedida: [null,[Validators.required]],
      codigoCategoria: [null,[Validators.required]],
      codigoSubCategoria: [null,[Validators.required]],
      codigoProveedor: [null,[Validators.required]],
      codigoAlmacenes: [null,[Validators.required]],
      nombre: [null,[Validators.required]],
      stock: [null,[Validators.required]],
      precio: [null,[Validators.required]],
      imagen: [null,[Validators.required]],
      descripcion: [null,[Validators.required]],
    });
  }




  ngOnInit(): void {

    this.myForm.patchValue(this.producto)


  }

  guardar()
  {
    this.productoEnvio= this.myForm.getRawValue();

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
    this._productoService.create(this.productoEnvio).subscribe({
      next:(data:ResponseProducto)=>{
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

    this._productoService.update(this.productoEnvio).subscribe({
      next:(data:ResponseProducto)=>{
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
