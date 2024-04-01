import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestCategoria } from '../models/categoria-request.model';
import { ResponseCategoria } from '../models/categoria-response.model';

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
