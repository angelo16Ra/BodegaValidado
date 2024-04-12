

import { CommonModule } from '@angular/common';
import { alert_error, alert_success, convertToBoolean } from '../../../../../functions/general.functions';
import { MantPedidoListComponent } from '../mant-pedido-list/mant-pedido-list.component';
import { SharedModule } from '../../../../shared/shared.module';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Vpedido } from '../../../models/VPedido.model';
import { ResponseUsuario } from '../../../models/usuario.response.model';
import { ResponseProducto } from '../../../models/producto-response.model';
import { ResponseDetallePedido } from '../../../models/detallePedido-response.model';
import { ResponsePedido } from '../../../models/pedido-response.model';
import { PedidoService } from '../../../service/pedido.service';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { RequestPedido } from '../../../models/pedido-request.model';

@Component({
  selector: 'app-mant-pedido-register',
  standalone: true,
  imports: [
    MantPedidoListComponent,
    CommonModule,
    SharedModule,
    ReactiveFormsModule
  ],
  templateUrl: './mant-pedido-register.component.html',
  styleUrl: './mant-pedido-register.component.css'
})
export class MantPedidoRegisterComponent implements OnInit{

  @Input() title:string = "";
  @Input() pedido:Vpedido = new  Vpedido();
  @Input() accion:number = 0;
  @Input() tipoUsuario:ResponseUsuario[]=[];
  @Input() tipoProducto:ResponseProducto[]=[];
  @Input() tipoDetallePedido:ResponseDetallePedido[]=[];

  @Output() closeModalEmmit = new EventEmitter<boolean>();

  myForm:FormGroup;
  pedidoEnvio: RequestPedido = new RequestPedido(); 

  constructor(
    private fb:FormBuilder,
    private _pedidoService:PedidoService,

  )
  {
    this.myForm = this.fb.group({
      codigoPedido: [{ value: 0, disabled: true }, [Validators.required]],
      codigoUsuario: [null,[Validators.required]],
      codigoProducto: [null,[Validators.required]],
      codigoDetallePedido: [null,[Validators.required]],
      montoTotalPedido: [null,[Validators.required]],
      montoPagado: [null,[Validators.required]],
      vuelto: [null,[Validators.required]],
      registroPedido: [null,[Validators.required]],
      entregaPedido: [null,[Validators.required]],
    })
    
  }

  ngOnInit(): void {
    
    this.myForm.patchValue(this.pedido);
  }
  
  guardar()
  {
    this.pedidoEnvio= this.myForm.getRawValue();
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
    this._pedidoService.create(this.pedidoEnvio).subscribe({
      next:(data:ResponsePedido)=>{
        console.log(data);
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
    //lamar a nuestro servicio rest ==> crear un nuevo registro en base de datos
    this._pedidoService.update(this.pedidoEnvio).subscribe({
      next:(data:ResponsePedido)=>{
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
