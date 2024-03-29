import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-mant-usuario-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule
    
  ],
  templateUrl: './mant-usuario-list.component.html',
  styleUrl: './mant-usuario-list.component.css'
})
export class MantUsuarioListComponent {

}
