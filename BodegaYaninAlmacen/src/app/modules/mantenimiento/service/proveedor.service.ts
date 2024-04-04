import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestProveedor } from '../models/proveedor-request.model';
import { ResponseProveedor } from '../models/proveedor-response.model';

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
