using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Almacen
{
    public class RequestMenu
    {
        public int CodigoMenus { get; set; }
        public string? Nombre { get; set; }
        public string? Icono { get; set; }
        public string Url { get; set; } = null!;
    }
}
