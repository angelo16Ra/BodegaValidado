using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Almacen
{
    public class ResponseDetallePedido
    {
        public int CodigoDetallePedido { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal PrecioUnitario { get; set; }
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
