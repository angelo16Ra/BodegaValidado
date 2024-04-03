﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Almacen
{
    public class ResponsePersona
    {
        public int CodigoPersona { get; set; }
        public int CodigoDocumento { get; set; }
        public int CodigoRol { get; set; }
        public string NumeroDocumento { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string ApPaterno { get; set; } = null!;
        public string ApMaterno { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; } = null!;
        public string? Celular { get; set; }
    }
}