import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestPersona } from '../models/persona-request.model';
import { ResponsePersona } from '../models/persona-response.model';
import { RequestFilterGeneric } from '../../../models/request-filter-generic.model';
import { Observable } from 'rxjs';
import { ResponseFilterGeneric } from '../../../models/response-filter-generic.model';
import { Vpersona } from '../models/Vpersona.model';

@Injectable({
  providedIn: 'root'
})
export class PersonaService extends CrudService<RequestPersona,ResponsePersona>{

  constructor(
    protected override _http:HttpClient
  ) 
  {
    super(_http,urlConstans.persona)
  } 

  genericFilterView(request: RequestFilterGeneric): Observable<ResponseFilterGeneric<Vpersona>>{
    return this._http.post<ResponseFilterGeneric<Vpersona>>(`${urlConstans.persona}filter-view`,request)
  }
}