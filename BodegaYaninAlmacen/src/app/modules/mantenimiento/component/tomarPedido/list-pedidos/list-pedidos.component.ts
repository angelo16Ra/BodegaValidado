import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { SharedModule } from '../../../../shared/shared.module';
import { Router } from '@angular/router';
import { ListProductosComponent } from '../list-productos/list-productos.component';

@Component({
  selector: 'app-list-pedidos',
  standalone: true,
  imports: [
    ListProductosComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './list-pedidos.component.html',
  styleUrl: './list-pedidos.component.css'
})
export class ListPedidosComponent {
  orders = [
    { number: '1025501531351', status: 'pending' },
    { number: '1025501531351', status: 'pending' },
    { number: '1025501531351', status: 'pending' },
    { number: '1025501531351', status: 'pending' }
  ];

  constructor(private router: Router) {}

  takeOrder(order: any) {
    order.status = 'in-process';
    this.router.navigate(['/list-productos']);
  }
}
