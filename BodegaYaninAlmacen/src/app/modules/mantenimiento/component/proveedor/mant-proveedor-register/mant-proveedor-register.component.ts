import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { RequestProveedor } from '../../../models/proveedor-request.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MantProveedorListComponent } from '../mant-proveedor-list/mant-proveedor-list.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../../shared/shared.module';
import { ProveedorService } from '../../../service/proveedor.service';
import { alert_error, alert_success, convertToBoolean } from '../../../../../functions/general.functions';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { ResponseProveedor } from '../../../models/proveedor-response.model';

@Component({
  selector: 'app-mant-proveedor-register',
  standalone: true,
  imports: [
    MantProveedorListComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-proveedor-register.component.html',
  styleUrl: './mant-proveedor-register.component.css'
})
export class MantProveedorRegisterComponent implements OnInit{

  @Input() title:string = "";
  @Input() proveedor:RequestProveedor = new RequestProveedor();
  @Input() accion:number = 0;

  @Output() closeModalEmmit = new EventEmitter<boolean>();

  myForm:FormGroup;
  proveedorEnvio:RequestProveedor = new RequestProveedor();


  constructor(
    private fb: FormBuilder,
    private _proveedorService: ProveedorService,
  ) 
  {

    this.myForm = this.fb.group({
      codigoProveedor: [{ value: 0, disabled: true }, [Validators.required]],
      ruc: [null, [Validators.required]],
      razonSocial: [null, [Validators.required]],
      telefono: [null, [Validators.required]],
      correo: [null, [Validators.required]],
      fechaRegistro: [null, [Validators.required]],
      fechaActualizacion: [null, [Validators.required]],
      estado: [null, [Validators.required]],
    });
  }


  ngOnInit(): void {

    console.log("title ==>", this.title);
    console.log("proveedor ==>", this.proveedor);

    this.myForm.patchValue(this.proveedor)
  }

  guardar()
  {

    this.proveedorEnvio= this.myForm.getRawValue();

    this.proveedorEnvio.estado = convertToBoolean(this.proveedorEnvio.estado.toString());

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
    this._proveedorService.create(this.proveedorEnvio).subscribe({
      next:(data:ResponseProveedor)=>{
        alert_success("EXCELENTE","Se creo de manera correcta")
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

    this._proveedorService.update(this.proveedorEnvio).subscribe({
      next:(data:ResponseProveedor)=>{
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