using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Almacen
{
    public class ResponseAlmacene
    {
        public int CodigoAlmacenes { get; set; }
        public string Nombre { get; set; } = null!;
        public int CapacidadLimite { get; set; }
        public bool Estado { get; set; }
    }
}
