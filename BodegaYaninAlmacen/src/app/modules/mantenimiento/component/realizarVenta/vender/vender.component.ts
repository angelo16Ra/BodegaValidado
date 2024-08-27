import { CommonModule } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { Vproducto } from '../../../models/VProducto.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ResponseUnidadMedida } from '../../../models/unidadMedida-response.model';
import { ResponseCategoria } from '../../../models/categoria-response.model';
import { ResponseSubCategoria } from '../../../models/subCategoria-response.model';
import { ResponseProveedor } from '../../../models/proveedor-response.model';
import { ResponseAlmacene } from '../../../models/almacen-response.model';
import { ProductoService } from '../../../service/producto.service';
import { UnidadMedidaService } from '../../../service/unidad-medida.service';
import { CategoriaService } from '../../../service/categoria.service';
import { SubCategoriaService } from '../../../service/sub-categoria.service';
import { ProveedorService } from '../../../service/proveedor.service';
import { AlmacenService } from '../../../service/almacen.service';
import { Router } from '@angular/router';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { forkJoin } from 'rxjs';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-vender',
  standalone: true,
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './vender.component.html',
  styleUrl: './vender.component.css'
})
export class VenderComponent implements OnInit{


  requestFilterGeneric:RequestFilterGeneric = new RequestFilterGeneric();
  vProducto:Vproducto[] = [];
  productoSelect: Vproducto = new Vproducto();
  titleModal: string = "";
  accionModal: number = 0;
  myFormFilter: FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 5;
  request: RequestFilterGeneric = new RequestFilterGeneric();
  cantidad: number = 1;
  productosAgregados: Vproducto[] = [];
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
      descripcion: ["", []],
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
  
    this.myFormFilter.valueChanges.subscribe(() => {
      this.filtrar();
    });
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
  
  obtenerListas() {
    forkJoin([
      this._unidadMedidaService.getAll(),
      this._categoriaService.getAll(),
      this._subCategoriaService.getAll(),
      this._proveedorService.getAll(),
      this._almacenService.getAll(),
    ]).subscribe({
      next: (data: any) => {
        this.tipoUnidadMedida = data[0];
        this.tipoCategoria = data[1];
        this.tipoSubCategoria = data[2];
        this.tipoProveedor = data[3];
        this.tipoAlmacen = data[4];
      },
      error: (err) => {
        console.error("Error al obtener las listas:", err);
      },
      complete: () => {
        console.log("Listas obtenidas correctamente");
      }
    });
  }
  
  filtrar() {
    this.request.filtros = [];

    let valueForm = this.myFormFilter.getRawValue();
  
    if (valueForm.codigoProducto) {
      this.request.filtros.push({ name: "codigoProducto", value: valueForm.codigoProducto });
    }
  
    if (valueForm.nombre) {
      this.request.filtros.push({ name: "nombre", value: valueForm.nombre });
    }
  
    this._productoService.genericFilterView(this.request).subscribe({
      next: (data: ResponseFilterGeneric<Vproducto>) => {
        this.vProducto = data.lista;
        this.totalItems = data.totalRegistros;
      },
      error: () => {
        console.log("error");
      },
      complete: () => {
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
      "codigoProducto": '',
      "nombre": '',
      "stock": '',
      "precio": '',
      "imagen": '',
      "descripcion": '',
      "nomnombreMedida": '',
      "nombreCategoria": '',
      "nombreSub": '',
      "nombreProveedor": '',
      "nombreAlmacen": ''
    });
    this.filtrar();
  }
  
  seleccionarProducto(producto: Vproducto) {
    this.productoSelect = producto;
  }

  agregarProducto() {
    const productoAgregado = { ...this.productoSelect, cantidad: this.cantidad };
    this.productosAgregados.push(productoAgregado);

    this._route.navigate(['/realizarventa/list-productos'], {
      state: { productos: this.productosAgregados }
    });
  }
  
}
