import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestPersona } from '../models/persona-request.model';
import { ResponsePersona } from '../models/persona-response.model';

@Injectable({
  providedIn: 'root'
})
export class PersonaService extends CrudService<RequestPersona,ResponsePersona> {

  constructor(
    protected override _http:HttpClient,
  )
  {
    super(_http,urlConstans.persona);
  }
}