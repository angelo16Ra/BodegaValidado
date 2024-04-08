import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MantPedidoListComponent } from '../mant-pedido-list/mant-pedido-list.component';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SharedModule } from '../../../../shared/shared.module';
import { CommonModule } from '@angular/common';
import { Vpedido } from '../../../models/VPedido.model';
import { ResponseUsuario } from '../../../models/usuario.response.model';
import { ResponseProducto } from '../../../models/producto-response.model';
import { ResponseDetallePedido } from '../../../models/detallePedido-response.model';
import { PedidoService } from '../../../service/pedido.service';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { ResponsePedido } from '../../../models/pedido-response.model';
import { alert_error, alert_success } from '../../../../../functions/general.functions';

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
  pedidoEnvio: ResponsePedido = new ResponsePedido(); 

  constructor(
    private fb:FormBuilder,
    private _pedidoService:PedidoService,

  )
  {
    this.myForm = this.fb.group({
      codigoPedido: [{value:0,disabled: true},[Validators.required]],
      codigoUsuario: [{value:0,disabled: true},[Validators.required]],
      codigoProducto: [{value:0,disabled: true},[Validators.required]],
      codigoDetallePedido: [{value:0,disabled: true},[Validators.required]],
      montoTotal: [null,[Validators.required]],
      montoPagado: [null,[Validators.required]],
      vuelto: [null,[Validators.required]],
      registroPedido: [null,[Validators.required]],
      entregaPedido: [null,[Validators.required]],
      nombreUsuario: [null,[Validators.required]],
      nombreProducto: [null,[Validators.required]],
      cantidad: [null,[Validators.required]],
      precioTotal: [null,[Validators.required]],
      precioUnitario: [null,[Validators.required]]
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
    }
    
  }
  crearRegistro()
  {
    //lamar a nuestro servicio rest ==> crear un nuevo registro en base de datos
    this._pedidoService.create(this.pedidoEnvio).subscribe({
      next:(data:ResponsePedido)=>{
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
