import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { urlConstans } from '../../../constans/url.constans';
import { LoginResponse } from '../../../models/login-response.model';
import { ResponsePersona } from '../../../models/persona-response.model';
import { UsuarioLoginResponse } from '../../../models/usuario-login-response.model';
import { ResponseRol } from '../../mantenimiento/models/rol-response.model';
import { RequestLogin } from '../models/login-request.models';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private dataSubject = new Subject<LoginResponse>();
  data$ = this.dataSubject.asObservable();
  private userData: LoginResponse = {
    success: false,
    mensaje: '',
    token: '',
    tokenExpira: '',
    usuario: new UsuarioLoginResponse(),
    rol: new ResponseRol(),
    persona: new ResponsePersona()
  };

  constructor(private http: HttpClient) {
    // Recuperar datos del usuario al iniciar la aplicación
    const storedUserData = sessionStorage.getItem('userData');
    if (storedUserData) {
      this.userData = JSON.parse(storedUserData);
      this.dataSubject.next(this.userData);
    }
  }

  sendData(data: LoginResponse) {
    this.userData = data || {};
    this.dataSubject.next(this.userData);
    sessionStorage.setItem('userData', JSON.stringify(this.userData));
  }

  login(request: RequestLogin): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(urlConstans.auth, request);
  }

  getUserDataSync(): LoginResponse {
    return this.userData;
  }
}
