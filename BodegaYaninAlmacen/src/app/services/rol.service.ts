import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../constans/url.constans';
import { RequestRol } from '../models/rol-request.model';

@Injectable({
  providedIn: 'root'
})
export class RolService {

  /**
   * TODO: declaramos una variable url
   */

  private url:string = urlConstans.rol;



  constructor(
    protected http:HttpClient
  ) {
  
    }

  /**
   * TODO: OBTIENE LA LISTA DE ROLES
   */

  getAll(token:string){

    const httpheaders = new  HttpHeaders({
      'Content-type': 'application/JSON',
      'Authorization': `Bearer ${token}`
    })
    
    return this.http.get(this.url,{headers:httpheaders});


  }

  /**
   * TODO: CREA UN NUEVO ROL
   */
  create(token:string,request: RequestRol){


    const httpheaders = new  HttpHeaders({
      'Content-type': 'application/JSON',
      'Authorization': `Bearer ${token}`
    })
    
    return this.http.post(this.url,request,{headers:httpheaders});


  }


  /**
   * TODO: ACTUALIZA UN ROL
   */
  update(token:string,request: RequestRol){


    const httpheaders = new  HttpHeaders({
      'Content-type': 'application/JSON',
      'Authorization': `Bearer ${token}`
    })
    
    return this.http.put(this.url,request,{headers:httpheaders});

  }

  /**
   * TODO: ELIMINA UN ROL
   */
  delete(token:string, id:number) {
    const httpheaders = new  HttpHeaders({
      'Content-type': 'application/JSON',
      'Authorization': `Bearer ${token}`
    })
    
    return this.http.delete(this.url + id.toString(),{headers:httpheaders});


  }
}
