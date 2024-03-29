using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Almacen
{
    public class RequestPedido
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