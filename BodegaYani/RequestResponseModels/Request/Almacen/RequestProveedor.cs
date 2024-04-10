using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Almacen
{
    public class RequestProveedor
    {
        public int CodigoProveedor { get; set; }
        public string Nombre { get; set; } = null!;
        public string Ruc { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public bool Estado { get; set; } = false;
    }
}
