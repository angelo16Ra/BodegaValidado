using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Almacen
{
    public class ResponseSubCategoria
    {
        public int CodigoSubCategoria { get; set; }
        public int CodigoCategoria { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
        public string EstadoDescripcion
        {
            get
            {
                return Estado ? "Activo" : "Inactivo";
            }
        }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
