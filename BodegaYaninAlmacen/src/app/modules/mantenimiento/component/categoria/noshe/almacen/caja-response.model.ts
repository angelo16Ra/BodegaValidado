export class ResponseCaja {
    codigoCaja: number = 0;
    fecha: Date = new Date();
    usuarioApertura: string = "";
    usuarioCierre: string = "";
    estado: boolean = false;
    montoApertura: number = 0;
    montoCierre: number = 0;
    montoAdicional: number = 0;
}


this.request.filtros.push({name:"codigocajas", value: valueForm.codigocajas});
    this.request.filtros.push({name:"fecha", value: valueForm.fecha});
    this.request.filtros.push({name:"usuarioApertura", value: valueForm.capacidadLimite});
    this.request.filtros.push({name:"usuarioCierre", value: valueForm.estado});
    this.request.filtros.push({name:"estado", value: valueForm.estado});