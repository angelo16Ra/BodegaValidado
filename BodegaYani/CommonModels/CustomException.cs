using Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Comun
{
    public class CustomException : Exception
    {
        public string CodigoError { get; set; } = "";
        public string MensajeUsuario { get; set; } = "";

        public CustomException() : base()
        {

        }

        public CustomException(string CodigoError, string MensajeUsuario)
        {
            this.CodigoError = CodigoError;
            this.MensajeUsuario = MensajeUsuario;
        }


    }
}
