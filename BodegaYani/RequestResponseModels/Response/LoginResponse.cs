using RequestResponseModels.Request.Almacen;
using RequestResponseModels.Response.Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response
{
    public class LoginResponse
    {
        public bool Success { get; set; } = false;
        public string Mensaje { get; set; } = "Usuario y/o password incorrecto";
        public string Token { get; set; } = "";
        public string TokenExpira { get; set; } = "";
        public UsuarioLoginResponse Usuario { get; set; } = new UsuarioLoginResponse();
        public ResponsePersona Persona { get; set; } = new ResponsePersona();
        public ResponseRol Rol { get; set; } = new ResponseRol();
        // retornar rol al que le corresponde
    }
}
