using AutoMapper;
using Business.Almacen;
using DBBodegaYani.BodegaYani;
using IBusiness.Almacen;
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
    public class PersonaController : ControllerBase
    {
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IBusinessPersona _persona;
        private readonly IMapper _mapper;
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region constructor
        public PersonaController(IMapper mapper)
        {
            _mapper = mapper;
            _persona = new BusinessPersona(mapper);
        }
        #endregion constructor

        #region CRUD METHODS

        
        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA PERSONA
        /// </summary>
        /// <returns>List-PersonaResponse</returns>
        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ResponsePersona>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            return Ok(_persona.GetAll());
        }

        /// <summary>
        /// RETORNA LOS DATOS DE UNA PERSONAEN BASE AL DNI
        /// </summary>
        /// <returns>List-PersonaResponse</returns>
        [HttpGet("dni/{tipoDocumento}/{nroDocumento}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ResponsePersona>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult GetWithDni(string tipoDocumento, string nroDocumento)
        {
            Vpersona persona = new Vpersona();
            persona = _persona.GetByTipoNroDocumento(tipoDocumento, nroDocumento);
            return Ok(persona);
        }



        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>ResponsePersona</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponsePersona))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_persona.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA PERSONA
        /// </summary>
        /// <param name="request">RequestPersona</param>
        /// <returns>ResponsePersona</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponsePersona))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] RequestPersona request)
        {
            return Ok(_persona.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA PERSONA EN BASE A PAGINACIÓN Y FILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public IActionResult GetByFilter([FromBody] RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponsePersona> res = _persona.GetByFilter(request);

            return Ok(res);
        }

        /// <summary>
        /// RETORNA LA TABLA PERSONA EN BASE A PAGINACIÓN Y FILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter-view")]
        public IActionResult GetByFilterView([FromBody] RequestFilterGeneric request)
        {
            ResponseFilterGeneric<Vpersona> res = _persona.GetByFilterView(request);

            return Ok(res);
        }

        /// <summary>
        /// RETORNA LA TABLA PERSONA EN BASE A PAGINACIÓN Y FILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<RequestPersona> request)
        {
            List<ResponsePersona> res = _persona.CreateMultiple(request);

            return Ok(res);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA PERSONA
        /// </summary>
        /// <param name="request">RequestPersona</param>
        /// <returns>ResponsePersona</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponsePersona))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] RequestPersona request)
        {
            return Ok(_persona.Update(request));
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
            return Ok(_persona.Delete(id));
        }
        #endregion CRUD METHODS


    }
}
