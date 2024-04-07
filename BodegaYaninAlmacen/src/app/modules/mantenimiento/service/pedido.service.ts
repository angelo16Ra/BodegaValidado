import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestPedido } from '../models/pedido-request.model';
import { ResponsePedido } from '../models/pedido-response.model';
import { RequestFilterGeneric } from '../../../models/request-filter-generic.model';
import { ResponseFilterGeneric } from '../../../models/response-filter-generic.model';
import { Vpedido } from '../models/VPedido.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PedidoService  extends CrudService<RequestPedido,ResponsePedido>{

  constructor(
    protected override _http:HttpClient
  ) 
  {
    super(_http,urlConstans.pedido)
  } 

  genericFilterView(request: RequestFilterGeneric): Observable<ResponseFilterGeneric<Vpedido>>{
    return this._http.post<ResponseFilterGeneric<Vpedido>>(`${urlConstans.pedido}filter-view`,request)
  }
}
