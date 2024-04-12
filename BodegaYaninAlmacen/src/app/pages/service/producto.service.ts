import { HttpClient } from '@angular/common/http';
import { CrudService } from '../../modules/shared/services/crud.service';
import { RequestProducto } from '../models/producto-request.model';
import { ResponseProducto } from '../models/producto-response.model';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../constans/url.constans';
import { RequestFilterGeneric } from '../../models/request-filter-generic.model';
import { ResponseFilterGeneric } from '../../models/response-filter-generic.model';
import { Vproducto } from '../models/VProducto.model';
import { Observable } from 'rxjs';

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

