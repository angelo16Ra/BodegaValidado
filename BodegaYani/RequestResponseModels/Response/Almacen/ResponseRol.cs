using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Almacen
{
    public class ResponseRol
    {
        public int CodigoRol { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public bool Estado { get; set; } = false;

        public string EstadoDescripcion
        {
            get
            {
                return Estado ? "Activo" : "Inactivo";
            }
        }
    }
}
