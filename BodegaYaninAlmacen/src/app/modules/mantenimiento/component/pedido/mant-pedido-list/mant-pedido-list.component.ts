import { Component, OnInit, TemplateRef } from '@angular/core';
import { MantPedidoRegisterComponent } from '../mant-pedido-register/mant-pedido-register.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { Vpedido } from '../../../models/VPedido.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ResponseProducto } from '../../../models/producto-response.model';
import { ProductoService } from '../../../service/producto.service';
import { PedidoService } from '../../../service/pedido.service';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { forkJoin } from 'rxjs';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-mant-pedido-list',
  standalone: true,
  imports: [
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-pedido-list.component.html',
  styleUrl: './mant-pedido-list.component.css'
})
export class MantPedidoListComponent implements OnInit{
  config  = {
    backdrop: true,
    ignoreBackdropClick: true
  };
  
  requestFilterGeneric:RequestFilterGeneric = new RequestFilterGeneric();
  vPedido: Vpedido[]=[];
  modalRef?: BsModalRef;
  pedidoSelect: Vpedido = new Vpedido();
  titleModal: string = "";
  accionModal: number = 0;
  myFormFilter:FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 5;
  request: RequestFilterGeneric = new RequestFilterGeneric();

  
  tipoProducto: ResponseProducto [] = [];

  
  constructor(
    private _pedidoService: PedidoService,
    private modalService: BsModalService,
    private _productoService: ProductoService,

    private _route:Router,
    private fb: FormBuilder,
  )
  {
    this.myFormFilter= this.fb.group({
      codigoPedido: ["", []],
      montoTotalPedido: ["", []],
      montoPagado: ["", []],
      vuelto: ["", []],
      registroPedido: ["", []],
      entregaPedido: ["", []],
      cantidad: ["", []],
      precioUnitario: ["", []],
      precioTotal: ["", []],
      NombreProducto: ["", []],
    });
  }

  ngOnInit(): void {
    this.filtrar();
    this.listarPedido();
    this.obtenerListas();
  }


  listarPedido()
  {
    this._pedidoService.genericFilterView(this.requestFilterGeneric).subscribe({
      next: (data:ResponseFilterGeneric<Vpedido>) => {
        
        this.vPedido = data.lista;

        console.log(data);
      },

      error: (err) => {
        console.log(err);
      },

      complete: ()=>{
      }
    });
  }
  
  obtenerListas()
  {
    forkJoin([
      this._productoService.getAll(),
    ]).subscribe({
      next:(data:any) => {
        this.tipoProducto = data[1];
      },
      error:(err) => {
        
      },
      complete:() => {
        
      }
    })

  }

  
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, Object.assign({},{class: "gray modal-lg"},this.config));
  }

  getCloseModalEmmit(res:boolean){
    this.modalRef?.hide();
    if(res)
    {
      this.listarPedido();
    }
  }

  
  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"CodigoPedido", value: valueForm.codigoPedido});
    this.request.filtros.push({name:"MontoTotalPedido", value: valueForm.montoTotalPedido});
    this.request.filtros.push({name:"MontoPagado", value: valueForm.montoPagado});
    this.request.filtros.push({name:"Vuelto", value: valueForm.vuelto});
    this.request.filtros.push({name:"RegistroPedido", value: valueForm.registroPedido});
    this.request.filtros.push({name:"EntregaPedido", value: valueForm.entregaPedido});
    this.request.filtros.push({name:"Cantidad", value: valueForm.cantidad});
    this.request.filtros.push({name:"PrecioUnitario", value: valueForm.precioUnitario});
    this.request.filtros.push({name:"PrecioTotal", value: valueForm.precioTotal});
    this.request.filtros.push({name:"NombreProducto", value: valueForm.nombreProducto});

    this._pedidoService.genericFilterView(this.request).subscribe({
      next: (data: ResponseFilterGeneric<Vpedido> ) => {
        console.log(data);
        this.vPedido = data.lista;
        this.totalItems = data.totalRegistros;
      },
      error: ( ) => {
        console.log("error");
      },
      complete: ( ) => {
        console.log("completo");
      },
    });
    
  }


  changePage(event: PageChangedEvent){
    this.request.numeroPagina = event.page;
    // let numeroPagina = event.page;
    // console.log(numeroPagina);
    this.filtrar();
  }

  changeItemsPerPage()
  {
    this.request.cantidad = this.itemsPerPage;
    this.filtrar();
  }


  limpiar() {
    this.myFormFilter.reset({
      "codigoProducto": '',
      "nombre": '',
      "stock": '',
      "precio": '',
      "imagen": '',
      "descripcion": '',
      "nomnombreMedida": '',
      "nombreCategoria": '',
      "nombreSub": '',
      "nombreProveedor": '',
      "nombreAlmacen": ''
    });
    this.request = new RequestFilterGeneric(); 
    this.filtrar();
  }

}
