import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestAlmacene } from '../models/almacen-request.model';
import { ResponseAlmacene } from '../models/almacen-response.model';

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
