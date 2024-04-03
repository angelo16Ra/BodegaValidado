import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestUnidadMedida } from '../models/unidadMedida-request.model';
import { ResponseUnidadMedida } from '../models/unidadMedida-response.model';

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
