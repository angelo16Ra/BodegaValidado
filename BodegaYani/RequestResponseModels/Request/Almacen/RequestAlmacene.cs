using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Almacen
{
    public class RequestAlmacene
    {
        public int CodigoAlmacenes { get; set; }
        public string Nombre { get; set; } = null!;
        public int CapacidadLimite { get; set; }
        public bool Estado { get; set; }
    }
}
