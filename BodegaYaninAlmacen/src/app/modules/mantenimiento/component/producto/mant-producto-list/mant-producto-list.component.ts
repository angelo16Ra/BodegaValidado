import { CommonModule } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { forkJoin } from 'rxjs';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { SharedModule } from '../../../../shared/shared.module';
import { ResponseAlmacene } from '../../../models/almacen-response.model';
import { ResponseCategoria } from '../../../models/categoria-response.model';
import { ResponseProducto } from '../../../models/producto-response.model';
import { ResponseProveedor } from '../../../models/proveedor-response.model';
import { ResponseSubCategoria } from '../../../models/subCategoria-response.model';
import { ResponseUnidadMedida } from '../../../models/unidadMedida-response.model';
import { Vproducto } from '../../../models/VProducto.model';
import { AlmacenService } from '../../../service/almacen.service';
import { CategoriaService } from '../../../service/categoria.service';
import { ProductoService } from '../../../service/producto.service';
import { ProveedorService } from '../../../service/proveedor.service';
import { SubCategoriaService } from '../../../service/sub-categoria.service';
import { UnidadMedidaService } from '../../../service/unidad-medida.service';
import { MantProductoRegisterComponent } from '../mant-producto-register/mant-producto-register.component';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-mant-producto-list',
  standalone: true,
  imports: [
    MantProductoRegisterComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-producto-list.component.html',
  styleUrl: './mant-producto-list.component.css'
})
export class MantProductoListComponent implements OnInit{
  config  = {
    backdrop: true,
    ignoreBackdropClick: true
  };


  requestFilterGeneric:RequestFilterGeneric = new RequestFilterGeneric();
  vProducto:Vproducto[] = [];
  modalRef?: BsModalRef;
  productoSelect: Vproducto = new Vproducto();
  titleModal: string = "";
  accionModal: number = 0;
  myFormFilter:FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 3;
  request:RequestFilterGeneric = new RequestFilterGeneric();
  
  //
  tipoUnidadMedida: ResponseUnidadMedida[] = [];
  tipoCategoria: ResponseCategoria[] = [];
  tipoSubCategoria: ResponseSubCategoria[] = [];
  tipoProveedor:ResponseProveedor[] = [];
  tipoAlmacen:ResponseAlmacene[] = [];

  constructor(
    private _productoService: ProductoService,
    private modalService: BsModalService,
    private _unidadMedidaService: UnidadMedidaService,
    private _categoriaService: CategoriaService,
    private _subCategoriaService: SubCategoriaService,
    private _proveedorService: ProveedorService, 
    private _almacenService: AlmacenService,


    private _route:Router,
    private fb: FormBuilder,
    
  )
  {
    this.myFormFilter= this.fb.group({
      codigoProducto: ["", []],
      nombre: ["", []],
      stock: ["", []],
      precio: ["", []],
      nomnombreMedida: ["", []],
      nombreCategoria: ["", []],
      nombreSub: ["", []],
      nombreProveedor: ["", []],
      nombreAlmacen: ["", []],
    });
  }

  
  ngOnInit(): void {
    this.filtrar();
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

  nuevoRegistro(template: TemplateRef<any>)
  {
    this.productoSelect = new Vproducto();
    this.titleModal = "Nuevo Producto";
    this.accionModal = AccionMantConst.crear;
    this.openModal(template);
    
  }

  editarRegistro(template: TemplateRef<any>, producto: Vproducto )
  {
    this.productoSelect = producto;
    this.titleModal = "Editar Producto";
    this.accionModal = AccionMantConst.editar;
    this.openModal(template);
    
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

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  getCloseModalEmmit(res:boolean){
    this.modalRef?.hide();
    if(res)
    {
      this.listarProducto();
    }
  }
  filtrar()
  {
    let request: RequestFilterGeneric = new RequestFilterGeneric(); 
    let valueForm = this.myFormFilter.getRawValue();

    this.request.filtros.push({name:"codigoProducto:", value: valueForm.codigoProducto});
    this.request.filtros.push({name:"nombre:", value: valueForm.nombre});
    this.request.filtros.push({name:"stock:", value: valueForm.stock});
    this.request.filtros.push({name:"precio:", value: valueForm.precio});
    this.request.filtros.push({name:"nomnombreMedida:", value: valueForm.nomnombreMedida});
    this.request.filtros.push({name:"nombreCategoria:", value: valueForm.nombreCategoria});
    this.request.filtros.push({name:"nombreSub:", value: valueForm.nombreSub});
    this.request.filtros.push({name:"nombreProveedor:", value: valueForm.nombreProveedor});
    this.request.filtros.push({name:"nombreAlmacen:", value: valueForm.nombreAlmacen});

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
