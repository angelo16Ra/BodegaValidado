import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RequestAlmacene } from '../models/almacen-request.model';
import { ResponseAlmacene } from '../models/almacen-response.model';
import { CrudService } from '../../modules/shared/services/crud.service';
import { urlConstans } from '../../constans/url.constans';

@Injectable({
  providedIn: 'root'
})
export class AlmacenService extends CrudService<RequestAlmacene,ResponseAlmacene>{

  constructor(
    protected override _http:HttpClient
  ) 
  {
    super(_http,urlConstans.almacene)
  }
}
