export class RequestPedido {
    codigoPedido: number = 0;
    codigoUsuario: number = 0;
    codigoProducto: number = 0;
    CodigoDetallePedido: number = 0;
    MontoTotalPedido: number = 0;
    montoPagado: number = 0;
    vuelto: number = 0;
    registroPedido: Date = new Date();
    entregaPedido: Date = new Date();
    estado: boolean = false;
}
