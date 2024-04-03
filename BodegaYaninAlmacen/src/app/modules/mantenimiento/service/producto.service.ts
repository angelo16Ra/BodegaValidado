import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestProducto } from '../models/producto-request.model';
import { ResponseProducto } from '../models/producto-response.model';

@Injectable({
  providedIn: 'root'
})
export class ProductoService extends CrudService<RequestProducto,ResponseProducto>{

  constructor(
    protected override _http:HttpClient
  ) 
  {
    super(_http,urlConstans.producto)
  }
}

