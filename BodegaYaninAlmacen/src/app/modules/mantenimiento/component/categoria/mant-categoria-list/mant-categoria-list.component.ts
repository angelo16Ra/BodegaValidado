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
import { ResponseCaja } from '../../../models/caja-response.model';
import { ResponseCategoria } from '../../../models/categoria-response.model';
import { CajaService } from '../../../service/caja.service';
import { CategoriaService } from '../../../service/categoria.service';
import { MantCategoriaRegisterComponent } from '../mant-categoria-register/mant-categoria-register.component';

@Component({
  selector: 'app-mant-categoria-list',
  standalone: true,
  imports: [
    MantCategoriaRegisterComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-categoria-list.component.html',
  styleUrl: './mant-categoria-list.component.css'
})
export class MantCategoriaListComponent {
  
  categorias: ResponseCategoria[] = [];
  modalRef?: BsModalRef;
  categoriaSelect: ResponseCategoria = new  ResponseCategoria();
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
    private _categoriaService: CategoriaService
  ){
    this.myFormFilter= this.fb.group({
      codigoCategoria: ["", []],
      nombre: ["", []],
      descripcion: ["", []],
      estado: ["", []],
      fechaRegistro: ["", []],
      fechaActualizacion: ["", []],
    });
  }

  ngOnInit(): void {
    
    this.filtrar();

  }

  listarcategorias() {
    this._categoriaService.getAll().subscribe({
      next: (data: ResponseCategoria[]) => {
        console.log("Data", data);
        this.categorias = data;
      },
      error: (err) => {
        console.log("error ", err);
      },
      complete: () => {
        //algo
      },
    });
  }

  crearCategoria(template: TemplateRef<any>) {
    this.categoriaSelect = new ResponseCategoria();
    this.titleModal = "Crear un Almacén";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
  }

  editarCategoria(template: TemplateRef<any>, categoria: ResponseCategoria) {
    this.categoriaSelect = categoria;
    this.titleModal = "Modificar Categoria";
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
      this.listarcategorias();
    }
  }

  eliminarRegistro(codigoCategoria:number)
  {
    let result = confirm("¿Estas seguro de eliminar el registro?")

    if(result)
    {
      this._categoriaService.delete(codigoCategoria).subscribe({
        next:(data:number) => {
          alert("El registro fue eliminado de manera correcta");
        },
        error:() => {},
        complete:() => {
          this.listarcategorias();
        }
      })
    }
  }

  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigocajas", value: valueForm.codigocajas});
    this.request.filtros.push({name:"nombre", value: valueForm.nombre});
    this.request.filtros.push({name:"capacidadLimite", value: valueForm.capacidadLimite});
    this.request.filtros.push({name:"estado", value: valueForm.estado});
    this.request.filtros.push({name:"capacidadLimite", value: valueForm.capacidadLimite});
    this.request.filtros.push({name:"estado", value: valueForm.estado});

    this._categoriaService.genericFilter(this.request).subscribe({
      next: (data: ResponseFilterGeneric<ResponseCategoria> ) => {
        console.log(data);
        this.categorias = data.lista;
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
