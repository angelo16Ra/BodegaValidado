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
import { Vpedido } from '../../../models/VPedido.model';

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
  requestFilterGeneric: RequestFilterGeneric = new RequestFilterGeneric();
  vProducto: Vproducto[] = [];
  productoSelect: Vproducto = new Vproducto();
  myFormFilter: FormGroup;
  totalItems: number = 0;
  itemsPerPage: number = 5;
  request: RequestFilterGeneric = new RequestFilterGeneric();
  cantidad: number = 1;
  productosAgregados: Vpedido[] = [];

  constructor(
    private _productoService: ProductoService,
    private _unidadMedidaService: UnidadMedidaService,
    private _categoriaService: CategoriaService,
    private _subCategoriaService: SubCategoriaService,
    private _proveedorService: ProveedorService,
    private _almacenService: AlmacenService,
    private _route: Router,
    private fb: FormBuilder
  ) {
    this.myFormFilter = this.fb.group({
      codigoProducto: [""],
      nombre: [""],
      stock: [""],
      precio: [""],
      descripcion: [""],
      nomnombreMedida: [""],
      nombreCategoria: [""],
      nombreSub: [""],
      nombreProveedor: [""],
      nombreAlmacen: [""],
      montoPagado: [0],
      vuelto: [0],
      entregaPedido: [""]
    });
  }

  ngOnInit(): void {
    this.filtrar();
    this.obtenerListas();
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
        // Procesar listas aquí si es necesario
      },
      error: (err) => console.error("Error al obtener las listas:", err),
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
      error: (err) => console.log("Error al filtrar productos:", err),
    });
  }

  changePage(event: PageChangedEvent) {
    this.request.numeroPagina = event.page;
    this.filtrar();
  }

  changeItemsPerPage() {
    this.request.cantidad = this.itemsPerPage;
    this.filtrar();
  }

  limpiar() {
    this.myFormFilter.reset({
      codigoProducto: '',
      nombre: '',
      stock: '',
      precio: '',
      descripcion: '',
      nomnombreMedida: '',
      nombreCategoria: '',
      nombreSub: '',
      nombreProveedor: '',
      nombreAlmacen: '',
      montoPagado: 0,
      vuelto: 0,
      entregaPedido: ''
    });
    this.filtrar();
  }

  seleccionarProducto(producto: Vproducto) {
    this.productoSelect = producto;
  }

  agregarProducto() {
    const pedido: Vpedido = new Vpedido();
    pedido.codigoPedido = this.productosAgregados.length + 1;
    pedido.cantidad = this.cantidad;
    pedido.precioUnitario = this.productoSelect.precio;
    pedido.precioTotal = this.cantidad * this.productoSelect.precio;
    pedido.nombreProducto = this.productoSelect.nombre;
    pedido.codigoPedido = this.productoSelect.codigoProducto;
    this.productosAgregados.push(pedido);
  }

  calcularMontoTotal(): number {
    return this.productosAgregados.reduce((acc, curr) => acc + curr.precioTotal, 0);
  }

  guardarPedido() {
    if (this.productosAgregados.length === 0) {
      alert('No hay productos en el pedido.');
      return;
    }

    const pedido: Vpedido = new Vpedido();
    pedido.montoTotalPedido = this.calcularMontoTotal();
    pedido.montoPagado = this.myFormFilter.get('montoPagado')?.value || 0;
    pedido.vuelto = this.myFormFilter.get('vuelto')?.value || 0;
    pedido.registroPedido = new Date().toISOString();
    pedido.entregaPedido = this.myFormFilter.get('entregaPedido')?.value || '';

    // Aquí podrías hacer una llamada al servicio para guardar el pedido en el backend
    console.log('Pedido guardado:', pedido);
    alert('Pedido guardado correctamente.');
  }
}