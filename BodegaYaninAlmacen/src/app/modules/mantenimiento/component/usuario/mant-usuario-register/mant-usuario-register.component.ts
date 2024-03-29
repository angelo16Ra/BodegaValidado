import { Component } from '@angular/core';
import { MantUsuarioListComponent } from '../mant-usuario-list/mant-usuario-list.component';

@Component({
  selector: 'app-mant-usuario-register',
  standalone: true,
  imports: [
    MantUsuarioListComponent
  ],
  templateUrl: './mant-usuario-register.component.html',
  styleUrl: './mant-usuario-register.component.css'
})
export class MantUsuarioRegisterComponent {

}
