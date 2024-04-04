import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { error } from 'console';
import { RequestFilterGeneric } from '../../../../../models/request-filter-generic.model';
import { ResponseFilterGeneric } from '../../../../../models/response-filter-generic.model';
import { SharedModule } from '../../../../shared/shared.module';
import { Vproducto } from '../../../models/VProducto.model';
import { ProductoService } from '../../../service/producto.service';
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
