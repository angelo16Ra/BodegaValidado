import { CommonModule } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { Vpedido } from '../../../models/VPedido.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ResponseUsuario } from '../../../models/usuario.response.model';
import { ResponseProducto } from '../../../models/producto-response.model';
import { ResponseDetallePedido } from '../../../models/detallePedido-response.model';
import { PedidoService } from '../../../service/pedido.service';
import { UsuarioService } from '../../../service/usuario.service';
import { ProductoService } from '../../../service/producto.service';
import { DetallePedidoService } from '../../../service/detalle-pedido.service';
import { Router } from '@angular/router';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { forkJoin } from 'rxjs';
import { ListPedidosComponent } from '../list-pedidos/list-pedidos.component';

@Component({
  selector: 'app-list-productos',
  standalone: true,
  imports: [
    ListPedidosComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './list-productos.component.html',
  styleUrl: './list-productos.component.css'
})
export class ListProductosComponent implements OnInit{
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

  
  tipoUsuario: ResponseUsuario [] = [];
  tipoProducto: ResponseProducto [] = [];
  tipoDetallePedido: ResponseDetallePedido [] = []; 

  
  constructor(
    private _pedidoService: PedidoService,
    private modalService: BsModalService,
    private _usuarioService: UsuarioService,
    private _productoService: ProductoService,
    private _detallePedidoService: DetallePedidoService,

    private _route:Router,
    private fb: FormBuilder,
  )
  {
    this.myFormFilter= this.fb.group({
      codigoPedido: ["", []],
      registroPedido: ["", []],
      entregaPedido: ["", []],
      nombreUsuario: ["", []],
      nombreProducto: ["", []],
    });
  }

  ngOnInit(): void {
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
      this._usuarioService.getAll(),
      this._productoService.getAll(),
      this._detallePedidoService.getAll(),
    ]).subscribe({
      next:(data:any) => {
        this.tipoUsuario = data[0];
        this.tipoProducto = data[1];
        this.tipoDetallePedido = data[2];
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

}