using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModels
{
    public class TokenClaims
    {
        public int CodigoUsuario { get; set; } = 0;
        public string Nombre { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string CodigoRol { get; set; } = "";
        public string Estado { get; set; } = "";
    }
}
