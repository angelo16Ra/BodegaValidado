using System;
using System.Collections.Generic;
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
        public decimal MontoTotal { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal Vuelto { get; set; }
        public DateTime RegistroPedido { get; set; }
        public DateTime EntregaPedido { get; set; }
    }
}
