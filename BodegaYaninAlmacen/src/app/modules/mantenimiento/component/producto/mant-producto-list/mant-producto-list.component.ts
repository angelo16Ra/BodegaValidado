import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { SharedModule } from '../../../../shared/shared.module';
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
export class MantProductoListComponent {
  
}
