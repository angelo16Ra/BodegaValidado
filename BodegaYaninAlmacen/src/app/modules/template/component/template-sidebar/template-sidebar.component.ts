
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-template-sidebar',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
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
              { name: "Rol", url: "mantenimiento/rol", icon: "fa-solid fa-image-portrait" },
              // { name: "Usuario", url: "mantenimiento/usuario", icon: "fa-solid fa-user" },
              // { name: "Categoría", url: "mantenimiento/categoria", icon: "fas fa-dashboard" },
              // { name: "Tipo Documento", url: "mantenimiento/tipo-documento", icon: "fas fa-file" },
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
            // { name: "Usuario", url: "mantenimiento/usuario", icon: "fa-solid fa-user" },
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
