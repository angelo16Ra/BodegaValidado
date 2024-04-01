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
