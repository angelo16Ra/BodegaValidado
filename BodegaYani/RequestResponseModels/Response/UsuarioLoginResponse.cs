using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response
{
    public class UsuarioLoginResponse
    {
        //usuario
        public int CodigoUsuario { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        //persona
        public int CodigoPersona { get; set; }
        public string NumeroDocumento { get; set; } = null!;
        public string NombrePersona { get; set; } = null!;
        public string ApPaterno { get; set; } = null!;
        public string ApMaterno { get; set; } = null!;
        public string Sexo { get; set; } = null!;

        //rol
        public int CodigoRol { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Estado { get; set; } = false;
    }
}
