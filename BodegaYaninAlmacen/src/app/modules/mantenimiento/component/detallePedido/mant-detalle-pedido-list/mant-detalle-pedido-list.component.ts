import { Component, TemplateRef } from '@angular/core';
import { ResponseDetallePedido } from '../../../models/detallePedido-response.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup } from '@angular/forms';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { Router } from '@angular/router';
import { DetallePedidoService } from '../../../service/detalle-pedido.service';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { MantDetallePedidoRegisterComponent } from '../mant-detalle-pedido-register/mant-detalle-pedido-register.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../../shared/shared.module';

@Component({
  selector: 'app-mant-detalle-pedido-list',
  standalone: true,
  imports: [
    MantDetallePedidoRegisterComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-detalle-pedido-list.component.html',
  styleUrl: './mant-detalle-pedido-list.component.css'
})
export class MantDetallePedidoListComponent {
  config  = {
    backdrop: true,
    ignoreBackdropClick: true
  };

  detallePedido: ResponseDetallePedido[] = [];
  modalRef?: BsModalRef;
  detallePedidoSelect: ResponseDetallePedido = new  ResponseDetallePedido();
  titleModal: string = "";
  accionModal: number = 0; //1 crea, 2 edita, 3 eliminar
  myFormFilter: FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 3;
  request: RequestFilterGeneric = new RequestFilterGeneric();

  constructor(
    private _route:Router,
    private fb: FormBuilder,
    private modalService: BsModalService,
    private _detallePedidoService: DetallePedidoService
  ){
    this.myFormFilter= this.fb.group({
      codigoDetallePedido: ["", []],
      cantidad: ["", []],
      precioTotal: ["", []],
      precioUnitario: ["", []],
      estado: ["", []],
    });
  }

  ngOnInit(): void {
    
    this.filtrar();

  }

  listarDetallePedido() {
    this._detallePedidoService.getAll().subscribe({
      next: (data: ResponseDetallePedido[]) => {
        console.log("Data", data);
        this.detallePedido = data;
      },
      error: (err) => {
        console.log("error ", err);
      },
      complete: () => {
        //algo
      },
    });
  }

  crearDetallePedido(template: TemplateRef<any>) {
    this.detallePedidoSelect = new ResponseDetallePedido();
    this.titleModal = "Crear un detalle del pedido";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
  }

  editarDetallePedido(template: TemplateRef<any>, detallePedido: ResponseDetallePedido) {
    this.detallePedidoSelect = detallePedido;
    this.titleModal = "Modificar detalle del pedido";
    this.accionModal = AccionMantConst.editar;
    this.openModal(template);
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, Object.assign({},{class: "gray modal-lg"},this.config));
  }

  getCloseModalEmmit(res:boolean){
    this.modalRef?.hide();
    if(res)
    {
      this.listarDetallePedido();
    }
  }

  eliminarRegistro(codigoDetallePedido:number)
  {
    let result = confirm("¿Estas seguro de eliminar el registro?")

    if(result)
    {
      this._detallePedidoService.delete(codigoDetallePedido).subscribe({
        next:(data:number) => {
          alert("El registro fue eliminado de manera correcta");
        },
        error:() => {},
        complete:() => {
          this.listarDetallePedido();
        }
      })
    }
  }


  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigoDetallePedido", value: valueForm.codigoDetallePedido});
    this.request.filtros.push({name:"cantidad", value: valueForm.cantidad});
    this.request.filtros.push({name:"precioTotal", value: valueForm.precioTotal});
    this.request.filtros.push({name:"precioUnitario", value: valueForm.precioUnitario});
    this.request.filtros.push({name:"estado", value: valueForm.estado});

    this._detallePedidoService.genericFilter(this.request).subscribe({
      next: (data: ResponseFilterGeneric<ResponseDetallePedido> ) => {
        console.log(data);
        this.detallePedido = data.lista;
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
