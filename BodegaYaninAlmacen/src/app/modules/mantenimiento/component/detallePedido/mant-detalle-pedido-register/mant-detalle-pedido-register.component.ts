import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SharedModule } from '../../../../shared/shared.module';
import { MantDetallePedidoListComponent } from '../mant-detalle-pedido-list/mant-detalle-pedido-list.component';
import { RequestDetallePedido } from '../../../models/detallePedido-request.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DetallePedidoService } from '../../../service/detalle-pedido.service';
import { alert_error, alert_success, convertToBoolean } from '../../../../../functions/general.functions';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { ResponseDetallePedido } from '../../../models/detallePedido-response.model';

@Component({
  selector: 'app-mant-detalle-pedido-register',
  standalone: true,
  imports: [
    MantDetallePedidoListComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-detalle-pedido-register.component.html',
  styleUrl: './mant-detalle-pedido-register.component.css'
})
export class MantDetallePedidoRegisterComponent implements OnInit{
  
  @Input() title:string = "";
  @Input() detallePedido:RequestDetallePedido = new RequestDetallePedido();
  @Input() accion:number = 0;

  @Output() closeModalEmmit = new EventEmitter<boolean>();

  myForm:FormGroup;
  detallePedidoEnvio:RequestDetallePedido = new RequestDetallePedido();
  
  constructor(
    private fb: FormBuilder,
    private _detallePedidoService: DetallePedidoService,
  ) 
  {

    this.myForm = this.fb.group({
      codigoDetallePedido: [{ value: 0, disabled: true }, [Validators.required]],
      cantidad: [null, [Validators.required]],
      precioTotal: [null, [Validators.required]],
      precioUnitario: [null, [Validators.required]],
      estado: [null, [Validators.required]],      
    });
  }

  ngOnInit(): void {

    console.log("title ==>", this.title);
    console.log("detallePedido ==>", this.detallePedido);

    this.myForm.patchValue(this.detallePedido)
  }

  guardar()
  {

    this.detallePedidoEnvio= this.myForm.getRawValue();

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
    this._detallePedidoService.create(this.detallePedidoEnvio).subscribe({
      next:(data:ResponseDetallePedido)=>{
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

    this._detallePedidoService.update(this.detallePedidoEnvio).subscribe({
      next:(data:ResponseDetallePedido)=>{
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
