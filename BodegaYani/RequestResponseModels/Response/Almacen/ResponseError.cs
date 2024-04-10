using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponseModels.Response.Almacen
{
    public class ResponseError
    {
        public int CodigoError { get; set; }
        public string? Urls { get; set; }
        public string? Controller { get; set; }
        public string? Ips { get; set; }
        public string? Method { get; set; }
        public string? UserAgent { get; set; }
        public string? Host { get; set; }
        public string? ClassComponent { get; set; }
        public string? FunctionName { get; set; }
        public int LineNumber { get; set; }
        public string? Error1 { get; set; }
        public string? StackTrace { get; set; }
        public short Statu { get; set; }
        public string? Request { get; set; }
        public int ErrorCode { get; set; }
        public int? CodigoPersona { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizar { get; set; }
        public int? CodigoUsuario { get; set; }
    }
}
