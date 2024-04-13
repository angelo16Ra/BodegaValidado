import { Component, OnInit } from '@angular/core';
import { SharedModule } from '../../modules/shared/shared.module';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { RequestFilterGeneric } from '../../models/request-filter-generic.model';
import { Vproducto } from '../models/VProducto.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ProductoService } from '../service/producto.service';
import { UnidadMedidaService } from '../service/unidad-medida.service';
import { CategoriaService } from '../service/categoria.service';
import { SubCategoriaService } from '../service/sub-categoria.service';
import { ProveedorService } from '../service/proveedor.service';
import { AlmacenService } from '../service/almacen.service';
import { ResponseFilterGeneric } from '../../models/response-filter-generic.model';
import { forkJoin } from 'rxjs';
import { ResponseUnidadMedida } from '../models/unidadMedida-response.model';
import { ResponseCategoria } from '../models/categoria-response.model';
import { ResponseSubCategoria } from '../models/subCategoria-response.model';
import { ResponseProveedor } from '../models/proveedor-response.model';
import { ResponseAlmacene } from '../models/almacen-response.model';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-catalogo',
  standalone: true,
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    ReactiveFormsModule
  ],
  templateUrl: './catalogo.component.html',
  styleUrl: './catalogo.component.css'
})
export class CatalogoComponent implements OnInit{

  requestFilterGeneric: RequestFilterGeneric = new RequestFilterGeneric();
  vProducto: Vproducto[] = [];
  modalRef?: BsModalRef;
  productoSelect: Vproducto = new Vproducto();
  myFormFilter: FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 5;
  request: RequestFilterGeneric = new RequestFilterGeneric();
  

  tipoUnidadMedida: ResponseUnidadMedida[] = [];
  tipoCategoria: ResponseCategoria[] = [];
  tipoSubCategoria: ResponseSubCategoria[] = [];
  tipoProveedor: ResponseProveedor[] = [];
  tipoAlmacen: ResponseAlmacene[] = [];

  
  constructor(
    private _productoService: ProductoService,
    private modalService: BsModalService,
    private _unidadMedidaService: UnidadMedidaService,
    private _categoriaService: CategoriaService,
    private _subCategoriaService: SubCategoriaService,
    private _proveedorService: ProveedorService,
    private _almacenService: AlmacenService,
    private _route: Router,
    private fb: FormBuilder,
  ) {
    this.myFormFilter = this.fb.group({
      codigoProducto: ["", []],
      nombre: ["", []],
      stock: ["", []],
      precio: ["", []],
      descripcion: ["", []],
    });
  }

  ngOnInit(): void {
    this.listarProducto();
    this.obtenerListas();
  }

  listarProducto()
  {
    this._productoService.genericFilterView(this.requestFilterGeneric).subscribe({
      next: (data:ResponseFilterGeneric<Vproducto>) => {

        this.vProducto = data.lista;

        console.log(data);
      },

      error: (err) => {
        console.log(err);
      },

      complete: ()=>{
      }
    });
  }

  getCloseModalEmmit(res:boolean){
    this.modalRef?.hide();
    if(res)
    {
      this.listarProducto();
    }
  }


  obtenerListas()
  {
    forkJoin([
      this._unidadMedidaService.getAll(),
      this._categoriaService.getAll(),
      this._subCategoriaService.getAll(),
      this._proveedorService.getAll(),
      this._almacenService.getAll(),
    ]).subscribe({
      next:(data:any) => {
        this.tipoUnidadMedida = data[0];
        this.tipoCategoria = data[1];
        this.tipoSubCategoria = data[2];
        this.tipoProveedor = data[3];
        this.tipoAlmacen = data[4];
      },
      error:(err) => {
        
      },
      complete:() => {
        
      }
    })
  }

  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigoProducto", value: valueForm.codigoProducto});
    this.request.filtros.push({name:"nombre", value: valueForm.nombre});
    this.request.filtros.push({name:"stock", value: valueForm.stock});
    this.request.filtros.push({name:"precio", value: valueForm.precio});
    this.request.filtros.push({name:"imagen", value: valueForm.imagen});
    this.request.filtros.push({name:"descripcion", value: valueForm.descripcion});
    this.request.filtros.push({name:"nomnombreMedida", value: valueForm.nomnombreMedida});
    this.request.filtros.push({name:"nombreCategoria", value: valueForm.nombreCategoria});
    this.request.filtros.push({name:"nombreSub", value: valueForm.nombreSub});
    this.request.filtros.push({name:"nombreProveedor", value: valueForm.nombreProveedor});
    this.request.filtros.push({name:"nombreAlmacen", value: valueForm.nombreAlmacen});

    this._productoService.genericFilterView(this.request).subscribe({
      next: (data: ResponseFilterGeneric<Vproducto> ) => {
        console.log(data);
        this.vProducto = data.lista;
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
