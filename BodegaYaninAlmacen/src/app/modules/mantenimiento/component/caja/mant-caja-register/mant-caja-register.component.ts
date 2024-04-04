import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccionMantConst } from '../../../../../constans/general.constants';
import { convertToBoolean } from '../../../../../functions/general.functions';
import { SharedModule } from '../../../../shared/shared.module';
import { RequestCaja } from '../../../models/caja-request.model';
import { ResponseCaja } from '../../../models/caja-response.model';
import { CajaService } from '../../../service/caja.service';
import { MantCajaListComponent } from '../mant-caja-list/mant-caja-list.component';

@Component({
  selector: 'app-mant-caja-register',
  standalone: true,
  imports: [
    MantCajaListComponent,
    CommonModule,
    SharedModule
  ],
  templateUrl: './mant-caja-register.component.html',
  styleUrl: './mant-caja-register.component.css'
})
export class MantCajaRegisterComponent {
  
}