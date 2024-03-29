import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TemplateFooterComponent } from '../template-footer/template-footer.component';
import { TemplateHeaderComponent } from '../template-header/template-header.component';
import { TemplateSidebarComponent } from '../template-sidebar/template-sidebar.component';

@Component({
    selector: 'app-template',
    standalone: true,
    templateUrl: './template.component.html',
    styleUrl: './template.component.css',
    imports: [
        CommonModule,
        RouterModule,
        TemplateSidebarComponent, 
        TemplateHeaderComponent, 
        TemplateFooterComponent
    ]
})
export class TemplateComponent {

}
