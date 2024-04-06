import { Routes } from '@angular/router';
import { authGuard } from './guard/auth.guard';
import { PruebaComponent } from './pages/prueba/prueba.component';
import { WelcomeComponent } from './pages/welcome/welcome.component';


export const routes: Routes = [
    //se llama ruteo simple
    {
        path:'',component:WelcomeComponent
    },
    {
        path:'prueba',component:PruebaComponent
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
