import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { Vproducto } from '../../../models/VProducto.model';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductoService } from '../../../service/producto.service';
import { UnidadMedidaService } from '../../../service/unidad-medida.service';
import { CategoriaService } from '../../../service/categoria.service';
import { SubCategoriaService } from '../../../service/sub-categoria.service';
import { ProveedorService } from '../../../service/proveedor.service';
import { AlmacenService } from '../../../service/almacen.service';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs';
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
  styleUrls: ['./vender.component.css']
})
export class VenderComponent implements OnInit {
  requestFilterGeneric: RequestFilterGeneric = new RequestFilterGeneric();
  vProducto: Vproducto[] = [];
  productoSelect: Vproducto | null = null;
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
      montoPagado: [0],
      vuelto: [0],
      entregaPedido: [""]
    });
  }

  ngOnInit(): void {
    this.filtrar();
    this.obtenerListas();
    this.myFormFilter.get('nombre')?.valueChanges.subscribe(value => {
      this.filtrar();
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
      next: (data: any) => {},
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
      next: (data) => {
        this.vProducto = data.lista;
        this.totalItems = data.totalRegistros;
      },
      error: (err) => console.log("Error al filtrar productos:", err),
    });
  }

  changePage(event: PageChangedEvent) {
    this.request.numeroPagina = event.page;
    this.request.cantidad = event.itemsPerPage;
    this.filtrar();
  }

  changeItemsPerPage() {
    this.request.cantidad = this.itemsPerPage;
    this.filtrar();
  }

  seleccionarProducto(producto: Vproducto) {
    this.productoSelect = producto;
    this.cantidad = 1;
  }

  agregarProducto() {
    if (!this.productoSelect || this.cantidad <= 0) {
      alert("Seleccione un producto y agregue una cantidad válida.");
      return;
    }
  
    let pedido = new Vpedido();
    pedido.codigoPedido = this.productosAgregados.length + 100;
    pedido.nombreProducto = this.productoSelect.nombre;
    pedido.cantidad = this.cantidad;
    pedido.precioUnitario = this.productoSelect.precio;
    pedido.precioTotal = this.cantidad * this.productoSelect.precio;
    pedido.registroPedido = new Date().toISOString();
  
    // Agregar el pedido a la lista de productos agregados
    this.productosAgregados.push(pedido);
  
    // Reiniciar los valores de la selección
    this.productoSelect = null;
    this.cantidad = 1;  // Resetear la cantidad a 1
  }

  eliminarProducto(index: number) {
    this.productosAgregados.splice(index, 1);
  }

  calcularMontoTotal(): number {
    return this.productosAgregados.reduce((total, producto) => total + producto.precioTotal, 0);
  }

  calcularVuelto(): number {
    const montoPagado = this.myFormFilter.get('montoPagado')?.value || 0;
    const total = this.calcularMontoTotal();
    return +(montoPagado - total).toFixed(2);
  }

  guardarPedido() {
    if (this.productosAgregados.length === 0) {
      alert('No hay productos en el pedido.');
      return;
    }
  
    // Calcular el monto total y el vuelto
    const montoTotalPedido = this.calcularMontoTotal();
    const montoPagado = this.myFormFilter.get('montoPagado')?.value || 0;
    const vuelto = this.calcularVuelto();
    const registroPedido = new Date().toISOString();
  
    // Obtener el valor de entregaPedido desde el formulario
    const entregaPedido = this.myFormFilter.get('entregaPedido')?.value || '';
  
    // Asignar estos valores a cada producto agregado
    this.productosAgregados.forEach(producto => {
      producto.montoTotalPedido = montoTotalPedido;
      producto.montoPagado = montoPagado;
      producto.vuelto = vuelto;
      producto.registroPedido = registroPedido;
      producto.entregaPedido = entregaPedido; // Aquí asignamos el día de entrega
    });
  
    // Imprimir en consola los productos agregados con los datos completos
    console.log('Productos agregados:', this.productosAgregados);
  
    if (montoTotalPedido <= 0) {
      alert('El total del pedido debe ser mayor a 0.');
      return;
    }
  
    // Aquí deberías hacer la llamada al backend o servicio correspondiente para guardar el pedido
    console.log('Pedido guardado:', this.productosAgregados);
  
    alert('Pedido guardado correctamente.');
  
    // Resetear productos y formulario después de guardar
    this.productosAgregados = [];
    this.myFormFilter.reset();
  }
  
  

  limpiar() {
    this.myFormFilter.reset();
    this.filtrar();
  }
}
