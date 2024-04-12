export class ResponseProveedor {
    codigoProveedor: number = 0;
    nombre: string = "";
    ruc: string = "";
    razonSocial: string = "";
    telefono: string = "";
    correo: string = "";
    fechaRegistro: Date = new Date();
    fechaActualizacion: Date = new Date();
    estado: boolean = false;
}