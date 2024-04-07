import { Routes } from '@angular/router';
import { authGuard } from './guard/auth.guard';
import { PruebaComponent } from './pages/prueba/prueba.component';
import { WelcomeComponent } from './pages/welcome/welcome.component';
import { CatalogoComponent } from './pages/catalogo/catalogo.component';
import { ComunidadComponent } from './pages/comunidad/comunidad.component';
import { InformacionComponent } from './pages/informacion/informacion.component';
import { ServiciosComponent } from './pages/servicios/servicios.component';


export const routes: Routes = [
    //se llama ruteo simple
    {
        path:'',component:WelcomeComponent
    },
    {
        path:'prueba',component:PruebaComponent
    },
    {
        path:'catalogo',component:CatalogoComponent
    },
    {
        path:'comunidad',component:ComunidadComponent
    },
    {
        path:'informacion',component:InformacionComponent
    },
    {
        path:'servicios',component:ServiciosComponent
    },


    //vamos gacer uso de lazy loading
    {
        path:'auth',loadChildren:() => import("./modules/auth/auth.module").then( x => x.AuthModule) 
    },
    {
        path:'dashboard',
        canActivate:[authGuard],
        loadChildren:() => import("./modules/template/template.module").then( x => x.TemplateModule) 
    },
    
    // {
    //     path:'**', redirectTo: '/404'
    // }
];
