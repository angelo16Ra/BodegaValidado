
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../../../shared/shared.module';

@Component({
  selector: 'app-template-sidebar',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    SharedModule
  ],
  templateUrl: './template-sidebar.component.html',
  styleUrl: './template-sidebar.component.css'
})
export class TemplateSidebarComponent implements OnInit{
  
  menu: any[]=[];
  ngOnInit(): void {

    this.rellenarMenu();

  }
  

  rellenarMenu()
  {
    let codigoRol = sessionStorage.getItem("codigoRol");

    switch(codigoRol)
    {
      //TODO: CUANDO ES ADMINISTRADOR
      case "100": //Administrador
        this.menu= [ 
          {
            name:"Mantenimiento",target:"TargerMantenimiento", icon:"fas fa-trash",
            subMenu:[
              { name: "almacen", url: "mantenimiento/almacen", icon: "fas fa-warehouse" },
              { name: "caja", url: "mantenimiento/caja", icon: "fas fa-cash-register" },
              { name: "Categoria", url: "mantenimiento/categoria", icon:"fas fa-list" },
              { name: "detalle de pedido", url: "mantenimiento/detalle-pedido", icon: "fas fa-clipboard-list" },
              { name: "pedido", url: "mantenimiento/pedido", icon: "fas fa-shopping-cart" },
              { name: "producto", url: "mantenimiento/producto", icon: "fas fa-box" },
              { name: "rol", url: "mantenimiento/rol", icon:"fas fa-user-lock" },
              { name: "sub categoria", url: "mantenimiento/sub-categoria", icon: "fas fa-list-alt" },
              { name: "Documento", url: "mantenimiento/tipo-documento", icon: "fas fa-file-alt" },
              { name: "Unidad de medida", url: "mantenimiento/unidad-medida", icon: "fas fa-file-alt" },
              { name: "usuario", url: "mantenimiento/usuario", icon:"fas fa-user" }

            ]
          },
        ]
        break;
      case "101": //Almacenero
      this.menu= [ 
        {
          name:"Almacen",target:"TargerMantenimiento", icon:"fas fa-trash",
          subMenu:[
            { name: "Rol", url: "mantenimiento/rol", icon: "fa-solid fa-image-portrait" },
            { name: "Persona", url: "mantenimiento/persona", icon: "fa-solid fa-user" },
            // { name: "Categoría", url: "mantenimiento/categoria", icon: "fas fa-dashboard" },
            // { name: "Tipo Documento", url: "mantenimiento/tipo-documento", icon: "fas fa-file" },
          ]
        },
      ]
      break;
      case "102": //Vendedora
        break;
      case "103": //otro
        break;
    }

  }

}
