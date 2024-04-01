import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestUsuario } from '../models/usuario-request.model';
import { ResponseUsuario } from '../models/usuario.response.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService extends CrudService<RequestUsuario,ResponseUsuario>{

  constructor(
    protected override _http:HttpClient,
  )
  {
    super(_http,urlConstans.usuario);
  }
}