using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Request.Almacen
{
    public class RequestCaja
    {
        public int CodigoCaja { get; set; }
        public int CodigoUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string? UsuarioApertura { get; set; }
        public string? UsuarioCierre { get; set; }
        public bool Estado { get; set; } = false;
        public decimal? MontoApertura { get; set; }
        public decimal? MontoCierre { get; set; }
        public decimal? MontoAdicional { get; set; }
    }
}
