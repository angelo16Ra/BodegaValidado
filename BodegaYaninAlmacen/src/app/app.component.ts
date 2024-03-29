import { CommonModule, NgFor } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { AfterViewChecked, AfterViewInit, Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    AppComponent,
    RouterOutlet,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgFor
  ],

  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
//export class AppComponent implements OnInit,AfterViewInit {

  // usuario = "admin";
  // password = "12345";

  // title = 'BodegaYaninAlmacen';

  // //declaramos la variante token
  // token:string ="";
  // rolRequest:RequestRol = new RequestRol();
  // roles: RequestRol[]=[];


  // constructor(
  //   private _authService: AuthService,
  //   private _rolService: RolService
  // ){

  // }


  // ngOnInit(): void {
    
  //   console.log("EVENTO ON INIT");
    
  // }


  // ngAfterViewInit(): void {
  //   // throw new Error('Method not implemented.');
  // }

  // iniciarSesion(){

  //   let loginRequest:any = {};


  //   console.log("usuario ==>", this.usuario);
  //   console.log("password ==>", this.password);
    
  //   loginRequest.userName =  this.usuario;
  //   loginRequest.password = this.password;


  //   this._authService.login(loginRequest).subscribe(
  //     {
  //       next:(data: any) => {
  //         console.log("IMPRIMIENDO RESUTADO LOGIN",data);
  //         this.listarRoles();
  //         this.token = data.token;
  //       },
  //       error:() => {},
  //       complete:() =>{}
  //     }
  //   );

  // }

  // /**
  //  * TODO: COMO PARAMETRO SE DEBE DE ENVIAR EL TOKEN AL MOMENTO DE INICIAR SESION
  //  */
  

  // listarRoles(){
  //   this.roles = [];
  //   this._authService.roles(this.token).subscribe(
  //     {
  //       next:(data: any) => {
  //         console.log("IMPRIMIENDO ROLES",data);
  //         this.roles = data;
          
  //       },
  //       error:() => {"NO SE PUDO OBTENER LA LISTA DE ERRORES"},
  //       complete:() =>{}
  //     }
  //   );
  // }


  // crearRol()
  // {
  //   if(this.rolRequest.codigoRol == 0)
  //   {
  //     this._rolService.create(this.token,this.rolRequest).subscribe({
  //       next:() => {
  //         alert('Registro Exitoso');
  //         this.listarRoles();
  //       },
  //       error:() => {
  //         alert( 'Error en el servidor' )
  //       },
  //       complete:() =>{}
  //     })
  //   }
  //   else{
  //     this._rolService.update(this.token,this.rolRequest).subscribe({
  //       next:() => {
  //         alert('Actualizacion Exitosa');
  //         this.listarRoles();
  //       },
  //       error:() => {
  //         alert( 'Error en el servidor' )
  //       },
  //       complete:() =>{}
  //     })
  //   }
  // }



  // rellenarValores(rol:RequestRol)
  // {
  //   this.rolRequest = rol;
     
  // }


  // eliminarRegistro(codigoRol:number){
  //   let eliminar = confirm("¿Estas seguro de eliminar?");
  //   if(eliminar)
  //   {
      
  //     this._rolService.delete(this.token, codigoRol).subscribe({
  //       next:() => {
  //         alert('Eliminado');
  //         this.listarRoles();
  //       },
  //       error:() => {
  //         alert( 'Error en el servidor' )
  //       },
  //       complete:() =>{}
  //     })

  //   }

    
  // }

}
