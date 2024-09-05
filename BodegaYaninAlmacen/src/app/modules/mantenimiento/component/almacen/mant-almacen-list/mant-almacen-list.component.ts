import { CommonModule } from '@angular/common';
import { Component, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { SharedModule } from '../../../../shared/shared.module';
import { ResponseAlmacene } from '../../../models/almacen-response.model';
import { AlmacenService } from '../../../service/almacen.service';
import { MantAlmacenRegisterComponent } from '../mant-almacen-register/mant-almacen-register.component';

@Component({
  selector: 'app-mant-almacen-list',
  standalone: true,
  imports: [
    MantAlmacenRegisterComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-almacen-list.component.html',
  styleUrl: './mant-almacen-list.component.css'
})
export class MantAlmacenListComponent {
  config  = {
    backdrop: true,
    ignoreBackdropClick: true
  };

  almacenes: ResponseAlmacene[] = [];
  modalRef?: BsModalRef;
  almacenSelect: ResponseAlmacene = new  ResponseAlmacene();
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
    private _almaceneService: AlmacenService
  ){
    this.myFormFilter= this.fb.group({
      codigoAlmacenes: ["", []],
      nombre: ["", []],
      capacidadLimite: ["", []],
      estado: ["", []],
    });
  }

  ngOnInit(): void {
    
    this.filtrar();

  }

  listarAlmacenes() {
    this._almaceneService.getAll().subscribe({
      next: (data: ResponseAlmacene[]) => {
        console.log("Data", data);
        this.almacenes = data;
      },
      error: (err) => {
        console.log("error ", err);
      },
      complete: () => {
        //algo
      },
    });
  }

  crearAlmacen(template: TemplateRef<any>) {
    this.almacenSelect = new ResponseAlmacene();
    this.titleModal = "Crear un Almacén";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
  }

  editarAlmacen(template: TemplateRef<any>, almacene: ResponseAlmacene) {
    this.almacenSelect = almacene;
    this.titleModal = "Modificar Almacén";
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
      this.listarAlmacenes();
    }
  }


  eliminarRegistro(codigoAlmacenes:number)
  {
    let result = confirm("¿Estas seguro de eliminar el registro?")

    if(result)
    {
      this._almaceneService.delete(codigoAlmacenes).subscribe({
        next:(data:number) => {
          alert("El registro fue eliminado de manera correcta");
        },
        error:() => {},
        complete:() => {
          this.listarAlmacenes();
        }
      })
    }
  }

  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigoAlmacenes", value: valueForm.codigoAlmacenes});
    this.request.filtros.push({name:"nombre", value: valueForm.nombre});
    this.request.filtros.push({name:"capacidadLimite", value: valueForm.capacidadLimite});
    this.request.filtros.push({name:"estado", value: valueForm.estado});

    this._almaceneService.genericFilter(this.request).subscribe({
      next: (data: ResponseFilterGeneric<ResponseAlmacene> ) => {
        console.log(data);
        this.almacenes = data.lista;
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
      "codigoAlmacenes": '',
      "nombre": '',
      "capacidadLimite": '',
      "estado": '',

    });
    this.request = new RequestFilterGeneric(); 
    this.filtrar();
  }

}
