export class ResponsePedido {
    codigoPedido: number = 0;
    codigoUsuario: number = 0;
    codigoProducto: number = 0;
    CodigoDetallePedido: number = 0;
    montoTotal: number = 0;
    montoPagado: number = 0;
    vuelto: number = 0;
    registroPedido: Date = new Date();
    entregaPedido: Date = new Date();
}
