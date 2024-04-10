using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Almacen
{
    public class RequestDetallePedido
    {
        public int CodigoDetallePedido { get; set; }
        public int CodigoPedido { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal PrecioUnitario { get; set; }
        public bool Estado { get; set; } = false;
    }
}
