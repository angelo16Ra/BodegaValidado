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
  VProducto:Vproducto[] = [];
  modalRef?: BsModalRef;
  productoSelect: Vproducto = new Vproducto();
  tileModal = "Editar Producto";
  accionModal = AccionMantConst.editar;

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

    
  )
  {

  }

  
  ngOnInit(): void {
    this.listarProducto();
    this.obtenerListas();
  }

  listarProducto()
  {
    this._productoService.genericFilterView(this.requestFilterGeneric).subscribe({
      next: (data:ResponseFilterGeneric<Vproducto>) => {

        this.VProducto = data.lista;

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
    this.tileModal = "Nuevo Producto";
    this.accionModal = AccionMantConst.editar;
    this.openModal(template);
    
  }

  editarRegistro(template: TemplateRef<any>, producto: Vproducto )
  {
    this.productoSelect = producto;
    this.tileModal = "Editar Producto";
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


}
