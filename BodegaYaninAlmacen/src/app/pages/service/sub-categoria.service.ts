import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RequestSubCategoria } from '../models/subCategoria-request.model';
import { ResponseSubCategoria } from '../models/subCategoria-response.model';
import { VsubCategoria } from '../models/VSubCategoria.model';
import { Observable } from 'rxjs';
import { CrudService } from '../../modules/shared/services/crud.service';
import { urlConstans } from '../../constans/url.constans';
import { RequestFilterGeneric } from '../../models/request-filter-generic.model';
import { ResponseFilterGeneric } from '../../models/response-filter-generic.model';

@Injectable({
  providedIn: 'root'
})
export class SubCategoriaService extends CrudService<RequestSubCategoria,ResponseSubCategoria>{

  constructor(
    protected override _http:HttpClient
  ) 
  {
    super(_http,urlConstans.subCategoria)
  } 

  genericFilterView(request: RequestFilterGeneric): Observable<ResponseFilterGeneric<VsubCategoria>>{
    return this._http.post<ResponseFilterGeneric<VsubCategoria>>(`${urlConstans.subCategoria}filter-view`,request)
  }
}

