using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Almacen
{
    public class RequestMovimientoCaja
    {
        public int CodigoMovimientoCaja { get; set; }
        public string? Tipo { get; set; }
        public decimal? Monto { get; set; }
        public int CodigoCaja { get; set; }
        public int CodigoPedido { get; set; }

    }
}
