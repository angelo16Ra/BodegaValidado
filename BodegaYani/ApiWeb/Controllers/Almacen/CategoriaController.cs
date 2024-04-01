using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Business.Almacen;
using IBusiness.Almacen;
using RequestResponseModels.Request.Almacen;
using RequestResponseModels.Generic;
using RequestResponseModels.Response.Almacen;
using Microsoft.AspNetCore.Authorization;

namespace ApiWeb.Controllers.Almacen
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    [AllowAnonymous]
    public class CategoriaController : ControllerBase
    {
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IBusinessCategoria _categoria;
        private readonly IMapper _mapper;
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region constructor
        public CategoriaController(IMapper mapper)
        {
            _mapper = mapper;
            _categoria = new BusinessCategoria(mapper);
        }
        #endregion constructor

        #region CRUD METHODS

        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA CATEGORIA
        /// </summary>
        /// <returns>List-CategoriaResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ResponseCategoria>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            return Ok(_categoria.GetAll());
        }

        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>ResponseCategoria</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseCategoria))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_categoria.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA CATEGORIA
        /// </summary>
        /// <param name="request">RequestCategoria</param>
        /// <returns>ResponseCategoria</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseCategoria))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] RequestCategoria request)
        {
            return Ok(_categoria.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA CATEGORIA EN BASE A PAGINACIÓN Y FILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public IActionResult GetByFilter([FromBody] RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseCategoria> res = _categoria.GetByFilter(request);

            return Ok(res);
        }

        /// <summary>
        /// RETORNA LA TABLA CATEGORIA EN BASE A PAGINACIÓN Y FILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<RequestCategoria> request)
        {
            List<ResponseCategoria> res = _categoria.CreateMultiple(request);

            return Ok(res);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA CATEGORIA
        /// </summary>
        /// <param name="request">RequestCategoria</param>
        /// <returns>ResponseCategoria</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseCategoria))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] RequestCategoria request)
        {
            return Ok(_categoria.Update(request));
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
            return Ok(_categoria.Delete(id));
        }
        #endregion CRUD METHODS


    }
}
