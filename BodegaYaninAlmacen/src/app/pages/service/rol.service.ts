import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestRol } from '../models/rol-request.model';
import { ResponseRol } from '../models/rol-response.model';

@Injectable({
  providedIn: 'root'
})
export class RolService extends CrudService<RequestRol,ResponseRol> {

  constructor(
    protected override _http:HttpClient,
  )
  {
    super(_http,urlConstans.rol);
  }
}