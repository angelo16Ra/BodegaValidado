using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Almacen
{
    public class RequestUsuario
    {
        public int CodigoUsuario { get; set; }
        public int CodigoRol { get; set; }
        public int CodigoPersona { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizar { get; set; }
    }
}
