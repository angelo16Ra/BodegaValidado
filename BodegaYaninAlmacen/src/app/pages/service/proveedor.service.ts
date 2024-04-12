import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RequestProveedor } from '../models/proveedor-request.model';
import { ResponseProveedor } from '../models/proveedor-response.model';
import { CrudService } from '../../modules/shared/services/crud.service';
import { urlConstans } from '../../constans/url.constans';

@Injectable({
  providedIn: 'root'
})
export class ProveedorService extends CrudService<RequestProveedor,ResponseProveedor> {

  constructor(
    protected override _http:HttpClient,
  )
  {
    super(_http,urlConstans.proveedor);
  }
}
