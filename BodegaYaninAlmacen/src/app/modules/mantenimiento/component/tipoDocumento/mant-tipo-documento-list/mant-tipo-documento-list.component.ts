import { Component, OnInit, TemplateRef } from '@angular/core';
import { ResponseTipoDocumento } from '../../../models/tipoDocumento-response.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { Router } from '@angular/router';
import { TipoDocumentoService } from '../../../service/tipo-documento.service';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { MantTipoDocumentoRegisterComponent } from '../mant-tipo-documento-register/mant-tipo-documento-register.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../../shared/shared.module';

@Component({
  selector: 'app-mant-tipo-documento-list',
  standalone: true,
  imports: [
    MantTipoDocumentoRegisterComponent,
    CommonModule,
    SharedModule,
    ReactiveFormsModule
  ],
  templateUrl: './mant-tipo-documento-list.component.html',
  styleUrl: './mant-tipo-documento-list.component.css'
})
export class MantTipoDocumentoListComponent implements OnInit {
  config  = {
    backdrop: true,
    ignoreBackdropClick: true
  };

  tipoDocumentos: ResponseTipoDocumento[] = [];
  modalRef?: BsModalRef;
  tipoDocumentoSelected: ResponseTipoDocumento = new  ResponseTipoDocumento();
  titleModal: string = "";
  accionModal: number = 0; //1 crea, 2 edita, 3 eliminar
  myFormFilter:FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 5;
  request: RequestFilterGeneric = new RequestFilterGeneric();


  constructor(
    private _route:Router,
    private fb: FormBuilder,
    private modalService: BsModalService,
    private _tipoDocumentoService:TipoDocumentoService

  ){
    this.myFormFilter= this.fb.group({
      codigoDocumento: ["", []],
      nombre: ["", []],
      descripcion: ["", []],
      
    });
  }

  ngOnInit(): void {
    
    this.filtrar();

  }

  listarDocumentos()
  {
    this._tipoDocumentoService.getAll().subscribe({
      next: (data:ResponseTipoDocumento[])=> {
        console.log("Data", data);
        this.tipoDocumentos=data;
        
      },
      error: (err)=> {
        console.log("error ",err);
      },
      complete: ()=> {
        //algo
      },
    });
  }

  crearDocumento(template: TemplateRef<any>)
  {
    this.tipoDocumentoSelected= new ResponseTipoDocumento();
    this.titleModal="Crear un Documento";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
  }

  editarDocumento(template: TemplateRef<any>, tipoDocumento:ResponseTipoDocumento)
  {
    this.tipoDocumentoSelected = tipoDocumento;
    this.titleModal="Modificar Documento";
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
      this.listarDocumentos();
    }
  }

  eliminarRegistro(codigoDocumento:number)
  {
    let result = confirm("¿Estas seguro de eliminar el registro?")

    if(result)
    {
      this._tipoDocumentoService.delete(codigoDocumento).subscribe({
        next:(data:number) => {
          alert("El registro fue eliminado de manera correcta");
        },
        error:() => {},
        complete:() => {
          this.listarDocumentos();
        }
      })
    }


  }
  
  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigoDocumento", value: valueForm.codigoDocumento});
    this.request.filtros.push({name:"nombre", value: valueForm.nombre});
    this.request.filtros.push({name:"descripcion", value: valueForm.descripcion});

    this._tipoDocumentoService.genericFilter(this.request).subscribe({
      next: (data: ResponseFilterGeneric<ResponseTipoDocumento> ) => {
        console.log(data);
        this.tipoDocumentos = data.lista;
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
      "codigoDocumento": '',
      "nombre": '',
      "descripcion": '',
    });
    this.filtrar();
  }



}
