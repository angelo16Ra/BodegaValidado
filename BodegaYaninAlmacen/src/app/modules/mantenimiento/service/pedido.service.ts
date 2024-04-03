import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestPedido } from '../models/pedido-request.model';
import { ResponsePedido } from '../models/pedido-response.model';

@Injectable({
  providedIn: 'root'
})
export class PedidoService extends CrudService<RequestPedido,ResponsePedido>{

  constructor(
    protected override _http:HttpClient
  ) 
  {
    super(_http,urlConstans.pedido)
  }
}
