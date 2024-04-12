import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RequestUnidadMedida } from '../models/unidadMedida-request.model';
import { ResponseUnidadMedida } from '../models/unidadMedida-response.model';
import { CrudService } from '../../modules/shared/services/crud.service';
import { urlConstans } from '../../constans/url.constans';

@Injectable({
  providedIn: 'root'
})
export class UnidadMedidaService extends CrudService<RequestUnidadMedida,ResponseUnidadMedida>{

  constructor(
    protected override _http:HttpClient
  ) 
  {
    super(_http,urlConstans.unidadMedida)
  }
}
