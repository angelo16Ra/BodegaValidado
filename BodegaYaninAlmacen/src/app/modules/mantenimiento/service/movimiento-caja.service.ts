import { Injectable } from '@angular/core';
import { CrudService } from '../../shared/services/crud.service';
import { RequestMovimientoCaja } from '../models/movimientoCaja-request.model';
import { ResponseMovimientoCaja } from '../models/movimientoCaja-response.model';
import { HttpClient } from '@angular/common/http';
import { urlConstans } from '../../../constans/url.constans';
import { RequestFilterGeneric } from '../../../models/request-filter-generic.model';
import { Observable } from 'rxjs';
import { ResponseFilterGeneric } from '../../../models/response-filter-generic.model';
import { VmovimientoCaja } from '../models/VmovimientoCaja.model';

@Injectable({
  providedIn: 'root'
})
export class MovimientoCajaService extends CrudService<RequestMovimientoCaja,ResponseMovimientoCaja>{

  constructor(
    protected override _http:HttpClient
  ) 
  {
    super(_http,urlConstans.movimientoCaja)
  } 

  genericFilterView(request: RequestFilterGeneric): Observable<ResponseFilterGeneric<VmovimientoCaja>>{
    return this._http.post<ResponseFilterGeneric<VmovimientoCaja>>(`${urlConstans.movimientoCaja}filter-view`,request)
  }
}