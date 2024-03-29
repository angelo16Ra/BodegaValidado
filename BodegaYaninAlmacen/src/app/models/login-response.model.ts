import { ResponseRol } from "../modules/mantenimiento/models/rol-response.model";
import { ResponsePersona } from "./persona-response.model";
import { UsuarioLoginResponse } from "./usuario-login-response.model";

export class LoginResponse {
    success: boolean=false;
    mensaje: string="";
    token: string="";
    tokenExpira: string="";
    usuario: UsuarioLoginResponse = new  UsuarioLoginResponse();
    persona: ResponsePersona = new  ResponsePersona();
    rol: ResponseRol = new ResponseRol();
}