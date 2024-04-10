using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Almacen
{
    public class ResponseMenu
    {
        public int CodigoMenus { get; set; }
        public string? Nombre { get; set; }
        public string? Icono { get; set; }
        public string Url { get; set; } = null!;
    }
}
