import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestTipoDocumento } from '../models/tipoDocumento-request.model';
import { ResponseTipoDocumento } from '../models/tipoDocumento-response.model';

@Injectable({
  providedIn: 'root'
})
export class TipoDocumentoService extends CrudService<RequestTipoDocumento,ResponseTipoDocumento>{

  constructor(
    protected override _http:HttpClient
  ) 
  {
    super(_http,urlConstans.tipoDocumento)
  }
}
