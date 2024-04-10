using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Almacen
{
    public class ResponseProducto
    {
        public int CodigoProducto { get; set; }
        public int CodigoUnidadMedida { get; set; }
        public int CodigoCategoria { get; set; }
        public int CodigoSubCategoria { get; set; }
        public int CodigoProveedor { get; set; }
        public int CodigoAlmacenes { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Stock { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
