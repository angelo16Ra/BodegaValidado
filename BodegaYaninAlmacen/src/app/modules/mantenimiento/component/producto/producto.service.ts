import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { urlConstans } from '../../../constans/url.constans';
import { RequestFilterGeneric } from '../../../models/request-filter-generic.model';
import { ResponseFilterGeneric } from '../../../models/response-filter-generic.model';
import { CrudService } from '../../shared/services/crud.service';
import { RequestProducto } from '../models/producto-request.model';
import { ResponseProducto } from '../models/producto-response.model';
import { Vproducto } from '../models/VProducto.model';

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

  genericFilterView(request: RequestFilterGeneric): Observable<ResponseFilterGeneric<Vproducto>>{
    return this._http.post<ResponseFilterGeneric<Vproducto>>(`${urlConstans.producto}filter-view`,request)
  }
}

