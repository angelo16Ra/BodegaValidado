import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MantAlmacenListComponent } from './component/almacen/mant-almacen-list/mant-almacen-list.component';
import { MantCajaListComponent } from './component/caja/mant-caja-list/mant-caja-list.component';
import { MantCategoriaListComponent } from './component/categoria/mant-categoria-list/mant-categoria-list.component';
import { MantDetallePedidoListComponent } from './component/detallePedido/mant-detalle-pedido-list/mant-detalle-pedido-list.component';
import { MantPedidoListComponent } from './component/pedido/mant-pedido-list/mant-pedido-list.component';
import { MantProductoListComponent } from './component/producto/mant-producto-list/mant-producto-list.component';
import { MantRolListComponent } from './component/rol/mant-rol-list/mant-rol-list.component';
import { MantSubCategoriaListComponent } from './component/subCategoria/mant-sub-categoria-list/mant-sub-categoria-list.component';
import { MantTipoDocumentoListComponent } from './component/tipoDocumento/mant-tipo-documento-list/mant-tipo-documento-list.component';
import { MantUnidadMedidaListComponent } from './component/unidadMedida/mant-unidad-medida-list/mant-unidad-medida-list.component';
import { MantUsuarioListComponent } from './component/usuario/mant-usuario-list/mant-usuario-list.component';

const routes: Routes = [
  {
    path:'almacen',component:MantAlmacenListComponent 
  },
  {
    path:'caja',component:MantCajaListComponent
  },
  {
    path:'categoria',component:MantCategoriaListComponent 
  },
  {
    path:'detalle-pedido',component:MantDetallePedidoListComponent 
  },
  {
    path:'pedido',component:MantPedidoListComponent 
  },
  {
    path:'producto',component:MantProductoListComponent 
  },
  {
    path:'rol',component:MantRolListComponent
  },
  {
    path:'sub-categoria',component:MantSubCategoriaListComponent 
  },
  {
    path:'tipo-documento',component:MantTipoDocumentoListComponent 
  },
  {
    path:'unidad-medida',component:MantUnidadMedidaListComponent 
  },
  {
    path:'usuario',component:MantUsuarioListComponent 
  }
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MantenimientoRoutingModule { }
