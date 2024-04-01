using AutoMapper;
using Business.Almacen;
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
    public class ProveedorController : ControllerBase
    {
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IBusinessProveedor _proveedor;
        private readonly IMapper _mapper;
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region constructor
        public ProveedorController(IMapper mapper)
        {
            _mapper = mapper;
            _proveedor = new BusinessProveedor(mapper);
        }
        #endregion constructor

        #region CRUD METHODS

        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA PROVEEDOR
        /// </summary>
        /// <returns>List-ProveedorResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ResponseProveedor>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            return Ok(_proveedor.GetAll());
        }

        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>ResponseProveedor</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseProveedor))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_proveedor.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA PROVEEDOR
        /// </summary>
        /// <param name="request">RequestProveedor</param>
        /// <returns>ResponseProveedor</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseProveedor))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] RequestProveedor request)
        {
            return Ok(_proveedor.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA PROVEEDOR EN BASE A PAGINACIÓN Y FILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public IActionResult GetByFilter([FromBody] RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseProveedor> res = _proveedor.GetByFilter(request);

            return Ok(res);
        }

        /// <summary>
        /// RETORNA LA TABLA PROVEEDOR EN BASE A PAGINACIÓN Y FILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<RequestProveedor> request)
        {
            List<ResponseProveedor> res = _proveedor.CreateMultiple(request);

            return Ok(res);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA PROVEEDOR
        /// </summary>
        /// <param name="request">RequestProveedor</param>
        /// <returns>ResponseProveedor</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseProveedor))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] RequestProveedor request)
        {
            return Ok(_proveedor.Update(request));
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
            return Ok(_proveedor.Delete(id));
        }
        #endregion CRUD METHODS


    }
}
