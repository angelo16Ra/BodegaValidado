
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
            name:"Administracion",target:"TargerMantenimiento", icon:"fas fa-trash",
            subMenu:[
              { name: "rol", url: "mantenimiento/rol", icon:"fas fa-user-lock" },
              { name: "usuario", url: "mantenimiento/usuario", icon:"fas fa-user" },
              { name: "Tipo Documento", url: "mantenimiento/tipo-documento", icon:"fas fa-address-card" }
            ]
          },
          {
            name:"Almacen",target:"TargerMantenimiento", icon:"fas fa-trash",
            subMenu:[
              { name: "almacen", url: "mantenimiento/almacen", icon: "fas fa-warehouse" },
              { name: "Categoria", url: "mantenimiento/categoria", icon:"fas fa-list" },
              { name: "producto", url: "mantenimiento/producto", icon: "fas fa-box" },
              { name: "pedido", url: "mantenimiento/pedido", icon: "fas fa-shopping-cart" },
              { name: "sub categoria", url: "mantenimiento/sub-categoria", icon: "fas fa-list-alt" },
              { name: "Proveedor", url: "mantenimiento/proveedor", icon: "fas fa-file-alt" },
              { name: "Unidad Medida", url: "mantenimiento/unidad-medida", icon: "fas fa-file-alt" },

            ]
          },
          {
            name:"Ventas",target:"TargerMantenimiento", icon:"fas fa-trash",
            subMenu:[
              { name: "caja", url: "mantenimiento/caja", icon: "fas fa-cash-register" },
              { name: "detalle de pedido", url: "mantenimiento/detalle-pedido", icon: "fas fa-clipboard-list" },
              { name: "pedido", url: "mantenimiento/pedido", icon: "fas fa-shopping-cart" },
            ]
          },
        ]
        break;


      case "101": //Almacenero
      this.menu= [ 
        {
          name:"Almacen",target:"TargerMantenimiento", icon:"fas fa-trash",
          subMenu:[
              { name: "almacen", url: "mantenimiento/almacen", icon: "fas fa-warehouse" },
              { name: "Categoria", url: "mantenimiento/categoria", icon:"fas fa-list" },
              { name: "producto", url: "mantenimiento/producto", icon: "fas fa-box" },
              { name: "pedido", url: "mantenimiento/pedido", icon: "fas fa-shopping-cart" },
              { name: "sub categoria", url: "mantenimiento/sub-categoria", icon: "fas fa-list-alt" },
              { name: "Proveedor", url: "mantenimiento/unidad-medida", icon: "fas fa-file-alt" },
              
          ]
        },
      ]
      break;


      case "102": //Vendedora
      this.menu= [ 
        {
          name:"Mantenimiento",target:"TargerMantenimiento", icon:"fas fa-trash",
          subMenu:[
            { name: "almacen", url: "mantenimiento/almacen", icon: "fas fa-warehouse" },
            { name: "Categoria", url: "mantenimiento/categoria", icon:"fas fa-list" },
            { name: "detalle de pedido", url: "mantenimiento/detalle-pedido", icon: "fas fa-clipboard-list" },
            { name: "pedido", url: "mantenimiento/pedido", icon: "fas fa-shopping-cart" },
            { name: "producto", url: "mantenimiento/producto", icon: "fas fa-box" },
            { name: "sub categoria", url: "mantenimiento/sub-categoria", icon: "fas fa-list-alt" },
            { name: "Documento", url: "mantenimiento/tipo-documento", icon: "fas fa-file-alt" },
            { name: "Unidad de medida", url: "mantenimiento/unidad-medida", icon: "fas fa-file-alt" },

          ]
        },
      ]
      break;
      case "103": //otro
        break;
    }

  }

}
