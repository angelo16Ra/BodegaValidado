import { Component, TemplateRef } from '@angular/core';
import { ResponseProveedor } from '../../../models/proveedor-response.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup } from '@angular/forms';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { MantProveedorRegisterComponent } from '../mant-proveedor-register/mant-proveedor-register.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../../shared/shared.module';
import { Router } from '@angular/router';
import { ProveedorService } from '../../../service/proveedor.service';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-mant-proveedor-list',
  standalone: true,
  imports: [
    MantProveedorRegisterComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-proveedor-list.component.html',
  styleUrl: './mant-proveedor-list.component.css'
})
export class MantProveedorListComponent {
  proveedors: ResponseProveedor[] = [];
  modalRef?: BsModalRef;
  proveedorSelect: ResponseProveedor = new  ResponseProveedor();
  titleModal: string = "";
  accionModal: number = 0; //1 crea, 2 edita, 3 eliminar
  myFormFilter: FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 5;
  request: RequestFilterGeneric = new RequestFilterGeneric();

  constructor(
    private _route:Router,
    private fb: FormBuilder,
    private modalService: BsModalService,
    private _proveedorService: ProveedorService
  ){
    this.myFormFilter= this.fb.group({
      codigoProveedor: ["", []],
      ruc: ["", []],
      razonSocial: ["", []],
      telefono: ["", []],
      correo: ["", []],
      fechaRegistro: ["", []],
      fechaActualizacion: ["", []],
      estado: ["", []],
    });
  }

  ngOnInit(): void {
    
    this.filtrar();

  }

  listarProveedor() {
    this._proveedorService.getAll().subscribe({
      next: (data: ResponseProveedor[]) => {
        console.log("Data", data);
        this.proveedors = data;
      },
      error: (err) => {
        console.log("error ", err);
      },
      complete: () => {
        //algo
      },
    });
  }

  crearProveedor(template: TemplateRef<any>) {
    this.proveedorSelect = new ResponseProveedor();
    this.titleModal = "Crear un Almacén";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
  }

  editarAlmacen(template: TemplateRef<any>, almacene: ResponseProveedor) {
    this.proveedorSelect = almacene;
    this.titleModal = "Modificar Almacén";
    this.accionModal = AccionMantConst.editar;
    this.openModal(template);
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  getCloseModalEmmit(res:boolean){
    this.modalRef?.hide();
    if(res)
    {
      this.listarProveedor();
    }
  }


  eliminarRegistro(codigoAlmacenes:number)
  {
    let result = confirm("¿Estas seguro de eliminar el registro?")

    if(result)
    {
      this._proveedorService.delete(codigoAlmacenes).subscribe({
        next:(data:number) => {
          alert("El registro fue eliminado de manera correcta");
        },
        error:() => {},
        complete:() => {
          this.listarProveedor();
        }
      })
    }
  }

  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigoProveedor", value: valueForm.codigoProveedor});
    this.request.filtros.push({name:"ruc", value: valueForm.ruc});
    this.request.filtros.push({name:"razonSocial", value: valueForm.razonSocial});
    this.request.filtros.push({name:"telefono", value: valueForm.telefono});
    this.request.filtros.push({name:"correo", value: valueForm.correo});
    this.request.filtros.push({name:"fechaRegistro", value: valueForm.fechaRegistro});
    this.request.filtros.push({name:"fechaActualizacion", value: valueForm.fechaActualizacion});
    this.request.filtros.push({name:"estado", value: valueForm.estado});

    this._proveedorService.genericFilter(this.request).subscribe({
      next: (data: ResponseFilterGeneric<ResponseProveedor> ) => {
        console.log(data);
        this.proveedors = data.lista;
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
