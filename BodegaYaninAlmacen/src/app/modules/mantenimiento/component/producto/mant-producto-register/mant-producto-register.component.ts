import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { SharedModule } from '../../../../shared/shared.module';
import { MantProductoListComponent } from '../mant-producto-list/mant-producto-list.component';

@Component({
  selector: 'app-mant-producto-register',
  standalone: true,
  imports: [
    MantProductoListComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-producto-register.component.html',
  styleUrl: './mant-producto-register.component.css'
})
export class MantProductoRegisterComponent {

}
