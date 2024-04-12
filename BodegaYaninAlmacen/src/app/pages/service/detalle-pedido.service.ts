import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { urlConstans } from '../../../constans/url.constans';
import { CrudService } from '../../shared/services/crud.service';
import { RequestDetallePedido } from '../models/detallePedido-request.model';
import { ResponseDetallePedido } from '../models/detallePedido-response.model';
import { RequestPedido } from '../models/pedido-request.model';

@Injectable({
  providedIn: 'root'
})
export class DetallePedidoService extends CrudService<RequestDetallePedido,ResponseDetallePedido>{

  constructor(
    protected override _http:HttpClient
  ) 
  {
    super(_http,urlConstans.detallePedido)
  }
}
