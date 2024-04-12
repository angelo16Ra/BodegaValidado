using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Almacen
{
    public class ResponsePedido
    {
        public int CodigoPedido { get; set; }
        public int CodigoUsuario { get; set; }
        public int CodigoProducto { get; set; }
        public int CodigoDetallePedido { get; set; }
        public decimal MontoTotalPedido { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal Vuelto { get; set; }
        public DateTime RegistroPedido { get; set; }
        public DateTime EntregaPedido { get; set; }
        public bool Estado { get; set; }
    }
}
