import { Component } from '@angular/core';
import { SharedModule } from '../../../shared/shared.module';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-template-header',
  standalone: true,
  imports: [
    SharedModule,
    RouterLink
  ],
  templateUrl: './template-header.component.html',
  styleUrl: './template-header.component.css'
})
export class TemplateHeaderComponent {

}
