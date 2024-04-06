import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable, throwError } from "rxjs";
import { catchError, retry } from 'rxjs/operators';
import { Router } from "@angular/router";
import { alert_error } from '../app/functions/general.functions';

@Injectable()
export class authInterceptor implements HttpInterceptor{
  
  constructor(
    private router:Router
  ) { }

  intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let token = sessionStorage.getItem("token");

    //SIMULAR LOS ERRORES

    let request = req;
    if (token) {
      request = req.clone(
        {
          setHeaders:{
          Authorization:`Bearer ${token}`
          }
        });
    }

    return  next.handle(request).pipe(
      catchError(
        (err: HttpErrorResponse)=> {
          let error = err.error;
          switch (err.status) {
            case 400: //TODO: BAD REQUEST
              alert_error("ERROR DE BAD REQUEST","datos incorrectos")
              break;
            case 401: //TODO: NO TIENES TOKEN | TOKEN INVALIDO | NO TIENES PERMISOS
              alert_error("SU SESION AH CADUCADO","vuelve a realizar el login")
              this.router.navigate(['']);
              break; 
            case 404: //TODO: URL NO ENCONTRADA 
              alert_error("RECURSO NO ENCONTRADO","")
              break;
            case 403: //TODO: NO TIENES PERMISOS PARA EJECUTAR UNA DETERMINADA ACCION
              alert_error("PERMISOS INSUFICIENTES","coordine con su administrador")
              break;
            case 500: //TODO: ERROR NO CONTROLADO
            alert_error("OCURRIO UN ERROR","intentelo mas tarde")
              break;
            case 0:
              alert_error("OCURRIO UN ERROR","no podemos comunicarnos con el servicio")
              break;
            default:
              alert_error("OCURRIO UN ERROR","no podemos comunicarnos con el servicio")
              break;
          }
          return throwError(() => { err });
      })
    );    
  }
}
