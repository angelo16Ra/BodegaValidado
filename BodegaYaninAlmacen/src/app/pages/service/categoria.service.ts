import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RequestCategoria } from '../models/categoria-request.model';
import { ResponseCategoria } from '../models/categoria-response.model';
import { CrudService } from '../../modules/shared/services/crud.service';
import { urlConstans } from '../../constans/url.constans';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService extends CrudService<RequestCategoria,ResponseCategoria> {

  constructor(
    protected override _http:HttpClient,
  )
  {
    super(_http,urlConstans.categoria);
  }
}
