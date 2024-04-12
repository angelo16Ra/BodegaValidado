import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestCaja } from '../models/caja-request.model';
import { ResponseCaja } from '../models/caja-response.model';
import { RequestFilterGeneric } from '../../../models/request-filter-generic.model';
import { ResponseFilterGeneric } from '../../../models/response-filter-generic.model';
import { Vcaja } from '../models/VCaja.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CajaService extends CrudService<RequestCaja,ResponseCaja>{

  constructor(
    protected override _http:HttpClient
  ) 
  {
    super(_http,urlConstans.caja)
  } 

  genericFilterView(request: RequestFilterGeneric): Observable<ResponseFilterGeneric<Vcaja>>{
    return this._http.post<ResponseFilterGeneric<Vcaja>>(`${urlConstans.caja}filter-view`,request)
  }
}
