import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestSubCategoria } from '../models/subCategoria-request.model';
import { ResponseSubCategoria } from '../models/subCategoria-response.model';

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
}
