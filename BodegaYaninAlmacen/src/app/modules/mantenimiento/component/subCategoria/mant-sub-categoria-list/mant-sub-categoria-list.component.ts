import { Component, OnInit, TemplateRef } from '@angular/core';
import { MantSubCategoriaRegisterComponent } from '../mant-sub-categoria-register/mant-sub-categoria-register.component';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { VsubCategoria } from '../../../models/VSubCategoria.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ResponseSubCategoria } from '../../../models/subCategoria-response.model';
import { SubCategoriaService } from '../../../service/sub-categoria.service';
import { ResponseCategoria } from '../../../models/categoria-response.model';
import { CategoriaService } from '../../../service/categoria.service';
import { Router } from '@angular/router';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { forkJoin } from 'rxjs';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-mant-sub-categoria-list',
  standalone: true,
  imports: [
    MantSubCategoriaRegisterComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-sub-categoria-list.component.html',
  styleUrl: './mant-sub-categoria-list.component.css'
})
export class MantSubCategoriaListComponent implements OnInit{
  config  = {
    backdrop: true,
    ignoreBackdropClick: true
  };
  
  requestFilterGeneric: RequestFilterGeneric = new RequestFilterGeneric();
  VsubCategoria:VsubCategoria[]= [];
  modalRef?: BsModalRef;
  subCategoriaSelect: VsubCategoria = new  VsubCategoria();
  titleModal: string = "";
  accionModal: number = 0;
  myFormFilter: FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 5;
  request: RequestFilterGeneric = new RequestFilterGeneric();

  tipoCategoria: ResponseCategoria[]=[];

  constructor(
    private _subCategoriaService: SubCategoriaService, 
    private modalService: BsModalService,
    private _categoriaService: CategoriaService,

    private _route:Router,
    private fb: FormBuilder,
    
    
  ){
    this.myFormFilter= this.fb.group({
      codigoSubCategoria: ["", []],
      nombre: ["", []],
      descripcion: ["", []],
      estado: ["", []],
      fechaRegistro: ["", []],
      fechaActualizacion: ["", []],
      nombreCategoria: ["", []],
    });
  }

  ngOnInit(): void {
    this.filtrar();
    this.listarSubCategorias();
    this.obtenerListas();

  }

  listarSubCategorias() {
    this._subCategoriaService.genericFilterView(this.requestFilterGeneric).subscribe({
      next: (data:ResponseFilterGeneric<VsubCategoria>) => {

        this.VsubCategoria = data.lista;

        console.log(data);
      },

      error: (err) => {
        console.log(err);
      },

      complete: ()=>{
      }
    });
  }

  nuevoRegistro(template: TemplateRef<any>) {
    this.subCategoriaSelect = new VsubCategoria();
    this.titleModal = "Nuevo subCategoria";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
  }

  editarRegistro(template: TemplateRef<any>, subCategoria: VsubCategoria) {
    this.subCategoriaSelect = subCategoria;
    this.titleModal = "Editar subCategoria";
    this.accionModal = AccionMantConst.editar;
    this.openModal(template);
  }

  obtenerListas()
  {
    forkJoin([
      this._categoriaService.getAll(),

    ]).subscribe({
      next:(data:any) => {
        this.tipoCategoria = data[0];
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
      this.listarSubCategorias();
    }
  }

  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigoSubCategoria", value: valueForm.codigoSubCategoria});
    this.request.filtros.push({name:"nombre", value: valueForm.nombre});
    this.request.filtros.push({name:"descripcion", value: valueForm.descripcion});
    this.request.filtros.push({name:"estado", value: valueForm.estado});
    this.request.filtros.push({name:"fechaRegistro", value: valueForm.fechaRegistro});
    this.request.filtros.push({name:"fechaActualizacion", value: valueForm.fechaActualizacion});
    this.request.filtros.push({name:"nombreCategoria", value: valueForm.nombreCategoria});

    this._subCategoriaService.genericFilterView(this.request).subscribe({
      next: (data: ResponseFilterGeneric<VsubCategoria> ) => {
        console.log(data);
        this.VsubCategoria = data.lista;
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
      "codigoSubCategoria": '',
      "nombre": '',
      "descripcion": '',
      "estado": '',
      "fechaRegistro": '',
      "fechaActualizacion": '',
      "nombreCategoria": '',
      
    });
    this.filtrar();
  }
}