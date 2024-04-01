using AutoMapper;
using Business;
using IBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RequestResponseModels.Generic;
using RequestResponseModels.Request;
using RequestResponseModels.Response;
using RequestResponseModels.Response.Almacen;
using Security;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace ApiWeb.Controllers
{

    /// <summary>
    /// METODOS PARA INICAR SESION
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {

        private readonly IAuthBusiness _authBusiness;
        private readonly IMapper _mapper;
        private readonly UtilEncriptarDesencriptar _cripto;

        public AuthController(IMapper mapper)
        {
            _mapper = mapper;
            _authBusiness = new AuthBusiness(mapper);
            _cripto = new UtilEncriptarDesencriptar();
        }

        /// <summary>
        /// Valida que el servicio este activo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            return Ok(true);
        }

        /// <summary>
        /// Metodo para realizar el inicio de sesión
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Login([FromBody] RequestLogin request)
        {
            LoginResponse loginResponse = _authBusiness.Login(request);
            
            loginResponse.Token = CreateToken(loginResponse);
            return Ok(loginResponse);

        }


        #region INICIO GENERACIÓN DE TOKEN

        private string CreateToken(LoginResponse oLoginResponse)
        {
            //obteniendo información de nuestro archivo appsettings.json
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
            configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
            IConfiguration configurationFile = configurationBuild.Build();

            //OBTENER EL TIEMPO DE VIDA DEL TOKEN
            int tiempoVida = int.Parse(configurationFile["Jwt:TimeJWTMin"]);
            //01 VAMOS A DETALLAR LOS CLAIMS
            //==> INFORMACIÓN QUE SE PUEDE ALMACENAR DENTRO DEL TOKEN GENERADO

            /**
             * VAMOS A DECLARAR LOS CLAIMS - LA INFORMACIÓN QUE SE VA A CARGAR DENTRO DEL TOKEN
             * 
             */

            //string stringClaims = JsonConvert.SerializeObject(oLoginResponse);
            //stringClaims = _cripto.encriptar_AES(stringClaims);

            var claims = new[] {
                 new Claim(JwtRegisteredClaimNames.Sub, configurationFile["Jwt:Subject"]),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),// - UTC-0
                 new Claim(ClaimTypes.Role, oLoginResponse.Rol.CodigoRol.ToString()),
                 new Claim("UserId", oLoginResponse.Usuario.CodigoUsuario.ToString()),
                 //new Claim("DisplayName", oLoginResponse.Nombres),
                 new Claim("UserName", oLoginResponse.Usuario.Username),
                 new Claim("RoleName", oLoginResponse.Rol.Nombre),
             };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationFile["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configurationFile["Jwt:Issuer"],
                configurationFile["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(tiempoVida),
                signingCredentials: signIn
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        #endregion INICIO GENERACIÓN DE TOKEN
    }
}
