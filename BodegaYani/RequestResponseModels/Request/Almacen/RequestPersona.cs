using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Almacen
{
    public class RequestPersona
    {
        public int CodigoPersona { get; set; }
        public int CodigoDocumento { get; set; }
        public string NumeroDocumento { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string ApPaterno { get; set; } = null!;
        public string ApMaterno { get; set; } = null!;
        public string? Sexo { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; } = null!;
        public string? Celular { get; set; }
        public bool Estado { get; set; }
    }
}
