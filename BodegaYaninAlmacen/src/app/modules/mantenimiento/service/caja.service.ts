import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestCaja } from '../models/caja-request.model';
import { ResponseCaja } from '../models/caja-response.model';

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
}

