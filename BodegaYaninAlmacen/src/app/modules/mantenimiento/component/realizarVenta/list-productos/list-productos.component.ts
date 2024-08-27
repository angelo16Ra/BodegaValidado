import { Component, OnInit } from '@angular/core';
import { Vproducto } from '../../../models/VProducto.model';
import { VenderComponent } from '../vender/vender.component';
import { ActivatedRoute } from '@angular/router';
import { SharedModule } from '../../../../shared/shared.module';
import { CommonModule } from '@angular/common';
import { routes } from '../../../../../app.routes';

@Component({
  selector: 'app-list-productos',
  standalone: true,
  imports: [
    CommonModule,
    SharedModule,
    VenderComponent
  ],
  templateUrl: './list-productos.component.html',
  styleUrl: './list-productos.component.css'
})
export class ListProductosComponent implements OnInit{
  productosAgregados: Vproducto[] = [];

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    // Recibir productos del estado de navegación
    this.productosAgregados = history.state.productos || [];
  }
}
