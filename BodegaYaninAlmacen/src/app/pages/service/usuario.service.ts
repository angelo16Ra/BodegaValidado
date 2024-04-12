import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { urlConstans } from '../../../constans/url.constans';
import { RequestFilterGeneric } from '../../../models/request-filter-generic.model';
import { ResponseFilterGeneric } from '../../../models/response-filter-generic.model';
import { CrudService } from '../../shared/services/crud.service';
import { RequestUsuario } from '../models/usuario-request.model';
import { ResponseUsuario } from '../models/usuario.response.model';
import { Vusuario } from '../models/VUsuario.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService extends CrudService<RequestUsuario,ResponseUsuario>{

  constructor(
    protected override _http:HttpClient
  ) 
  {
    super(_http,urlConstans.usuario)
  } 

  genericFilterView(request: RequestFilterGeneric): Observable<ResponseFilterGeneric<Vusuario>>{
    return this._http.post<ResponseFilterGeneric<Vusuario>>(`${urlConstans.usuario}filter-view`,request)
  }
}