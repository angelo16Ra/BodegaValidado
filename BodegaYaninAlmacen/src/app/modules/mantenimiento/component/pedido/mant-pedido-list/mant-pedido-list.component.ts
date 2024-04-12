import { Component, OnInit, TemplateRef } from '@angular/core';
import { MantPedidoRegisterComponent } from '../mant-pedido-register/mant-pedido-register.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { Vpedido } from '../../../models/VPedido.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { ResponseUsuario } from '../../../models/usuario.response.model';
import { ResponseProducto } from '../../../models/producto-response.model';
import { ResponseDetallePedido } from '../../../models/detallePedido-response.model';
import { ProductoService } from '../../../service/producto.service';
import { PedidoService } from '../../../service/pedido.service';
import { UsuarioService } from '../../../service/usuario.service';
import { DetallePedidoService } from '../../../service/detalle-pedido.service';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { forkJoin } from 'rxjs';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-mant-pedido-list',
  standalone: true,
  imports: [
    MantPedidoRegisterComponent,
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
  itemsPerPage: number = 3;
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

  nuevoRegistro(template: TemplateRef<any>)
  {
    this.pedidoSelect = new Vpedido();
    this.titleModal = "Nuevo Pedido";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
    
  }

  editarRegistro(template: TemplateRef<any>, pedido:Vpedido)
  {
    this.pedidoSelect = new Vpedido();
    this.titleModal = "editar Pedido";
    this.accionModal = AccionMantConst.editar;
    this.openModal(template);
    
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

  
  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigoPedido", value: valueForm.codigoPedido});
    this.request.filtros.push({name:"registroPedido", value: valueForm.registroPedido});
    this.request.filtros.push({name:"entregaPedido", value: valueForm.entregaPedido});
    this.request.filtros.push({name:"nombreUsuario", value: valueForm.nombreUsuario});
    this.request.filtros.push({name:"nombreProducto", value: valueForm.nombreProducto});

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


}
