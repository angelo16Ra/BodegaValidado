using AutoMapper;
using Business.Almacen;
using IBusiness.Almacen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModels.Generic;
using RequestResponseModels.Request.Almacen;
using RequestResponseModels.Response.Almacen;
using System.Net;

namespace ApiWeb.Controllers.Almacen
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [AllowAnonymous]
    public class RolController : ControllerBase
    {
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IBusinessRol _rol;
        private readonly IMapper _mapper;
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region constructor
        public RolController(IMapper mapper)
        {
            _mapper = mapper;
            _rol = new BusinessRol(mapper);
        }
        #endregion constructor

        #region CRUD METHODS

        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA ROL
        /// </summary>
        /// <returns>List-RolResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ResponseRol>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            return Ok(_rol.GetAll());
        }

        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>ResponseRol</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseRol))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_rol.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA ROL
        /// </summary>
        /// <param name="request">RequestRol</param>
        /// <returns>ResponseRol</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseRol))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] RequestRol request)
        {
            return Ok(_rol.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA CARGO EN BASE A PAGINACIÓN Y FILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public IActionResult GetByFilter([FromBody] RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseRol> res = _rol.GetByFilter(request);

            return Ok(res);
        }

        /// <summary>
        /// RETORNA LA TABLA CARGO EN BASE A PAGINACIÓN Y FILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<RequestRol> request)
        {
            List<ResponseRol> res = _rol.CreateMultiple(request);

            return Ok(res);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA ROL
        /// </summary>
        /// <param name="request">RequestRol</param>
        /// <returns>ResponseRol</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseRol))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] RequestRol request)
        {
            return Ok(_rol.Update(request));
        }

        /// <summary>
        /// ELIMINA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>cantidad de registros eliminados</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(int))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Delete(int id)
        {
            return Ok(_rol.Delete(id));
        }
        #endregion CRUD METHODS


    }
}
