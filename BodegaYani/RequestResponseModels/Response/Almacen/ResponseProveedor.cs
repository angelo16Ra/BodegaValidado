using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Almacen
{
    public class ResponseProveedor
    {
        public int CodigoProveedor { get; set; }
        public string Ruc { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public bool Estado { get; set; }
        public string EstadoDescripcion
        {
            get
            {
                return Estado ? "Activo" : "Inactivo";
            }
        }
    }
}
