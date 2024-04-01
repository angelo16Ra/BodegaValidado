using AutoMapper;
using Business.Almacen;
using DBBodegaYani.BodegaYani;
using IBusiness;
using IBusiness.Almacen;
using Microsoft.IdentityModel.Tokens;
using RequestResponseModels.Request;
using RequestResponseModels.Response;
using RequestResponseModels.Response.Almacen;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AuthBusiness : IAuthBusiness
    {
         //INYECCIÓN DE DEPENDECIAS//
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IBusinessUsuario _usuarioBussnies;
        private readonly IBusinessPersona _personaBussnies;
        private readonly IBusinessRol _rolBusiness;
        private readonly IMapper _mapper;
        //private readonly IRolBussnies _rolBussnies;
        private readonly UtilEncriptarDesencriptar _cripto;
        public AuthBusiness(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioBussnies = new BusinessUsuario(mapper);
            _personaBussnies = new BusinessPersona(mapper);
            _rolBusiness = new BusinessRol(mapper);
            _cripto = new UtilEncriptarDesencriptar();
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        public LoginResponse Login(RequestLogin request)
        {
            LoginResponse result = new LoginResponse();

            //01 VALIDAMOS QUE EL USUARIO EXISTA
            Vusuario usuario = _usuarioBussnies.BuscarPorNombreUsuario(request.UserName);
            if (usuario == null)
            {
                return result;
            }



            //02 VALIDAMOS QUE EL USUARIO EXISTA
            //02.01 ==> proceso de encriptar un texto
            string newPassword = _cripto.encriptar_AES(request.Password);
            //string newPassword = request.Contraseña;

            if (newPassword != usuario.Password)
            {
                return result;
            }

            result.Success = true;
            result.Mensaje = "LOGIN CORRECTO";

            result.Usuario = new UsuarioLoginResponse();
            result.Usuario.CodigoUsuario = usuario.CodigoUsuario;
            result.Usuario.Username = usuario.Username;
            result.Usuario.Password = usuario.Password;


            result.Rol = new ResponseRol();
            result.Rol.CodigoRol = usuario.CodigoRol;
            result.Rol.Nombre = usuario.Nombre;
            result.Rol.Estado = usuario.Estado;


            result.Persona = new ResponsePersona();
            result.Persona.CodigoPersona = usuario.CodigoPersona;
            result.Persona.NumeroDocumento = usuario.NumeroDocumento;
            result.Persona.Nombre = usuario.NombrePersona;
            result.Persona.ApMaterno = usuario.ApMaterno;
            result.Persona.ApPaterno = usuario.ApPaterno;
            result.Persona.Sexo = usuario.Sexo;


            // ESTE TIPO DE IMPLEMENTACIÓN NO ES LA MAS OPTIMA//
            /*
             * VAMOS A REALIZAR CONSULTAS INDEPENDIENTES
             * _rolBussnies
             * _personaBussnies
             */

            //busqueda del usuario
            //busqueda del rol
            return result;
        }

    }
}
