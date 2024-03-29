import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-template-sidebar',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule 
  ],
  templateUrl: './template-sidebar.component.html',
  styleUrl: './template-sidebar.component.css'
})
export class TemplateSidebarComponent {

}
