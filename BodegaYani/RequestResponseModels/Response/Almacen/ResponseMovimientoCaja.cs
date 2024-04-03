﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Almacen
{
    public class ResponseMovimientoCaja
    {
        public int CodigoMovimientoCaja { get; set; }
        public string? Tipo { get; set; }
        public decimal? Monto { get; set; }
        public int CodigoCaja { get; set; }
        public int CodigoPedido { get; set; }
    }
}