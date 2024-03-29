import { HttpInterceptorFn } from '@angular/common/http';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable, throwError } from "rxjs";
import { catchError } from 'rxjs/operators';
import { Router } from "@angular/router";

@Injectable()
export class authInterceptor implements HttpInterceptor{
  
  constructor(
    private router:Router
  ){

  }

  intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    let token = sessionStorage.getItem("token");


    let request = req;
    if(token){
      request = req.clone(
        {setHeaders:{
          Authorization:`Bearer ${token}`
      }
    });
  }


    return  next.handle(request);
  }
}
