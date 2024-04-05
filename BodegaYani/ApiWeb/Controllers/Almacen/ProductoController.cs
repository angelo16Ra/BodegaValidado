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
    public class ProductoController : ControllerBase
    {
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IBusinessProducto _producto;
        private readonly IMapper _mapper;
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region constructor
        public ProductoController(IMapper mapper)
        {
            _mapper = mapper;
            _producto = new BusinessProducto(mapper);
        }
        #endregion constructor

        #region CRUD METHODS

        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA PRODUCTO
        /// </summary>
        /// <returns>List-ProductoResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ResponseProducto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            return Ok(_producto.GetAll());
        }

        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>ResponseProducto</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseProducto))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_producto.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA PRODUCTO
        /// </summary>
        /// <param name="request">RequestProducto</param>
        /// <returns>ResponseProducto</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseProducto))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] RequestProducto request)
        {
            return Ok(_producto.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA PRODUCTO EN BASE A PAGINACIÓN Y FILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public IActionResult GetByFilter([FromBody] RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseProducto> res = _producto.GetByFilter(request);

            return Ok(res);
        }


        /// <summary>
        /// RETORNA LA TABLA PRODUCTO EN BASE A PAGINACIÓN Y FILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter-view")]
        public IActionResult GetByFilterView([FromBody] RequestFilterGeneric request)
        {
            ResponseFilterGeneric<Vproducto> res = _producto.GetByFilterView(request);

            return Ok(res);
        }



        /// <summary>
        /// RETORNA LA TABLA PRODUCTO EN BASE A PAGINACIÓN Y FILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<RequestProducto> request)
        {
            List<ResponseProducto> res = _producto.CreateMultiple(request);

            return Ok(res);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA PRODUCTO
        /// </summary>
        /// <param name="request">RequestProducto</param>
        /// <returns>ResponseProducto</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponseProducto))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] RequestProducto request)
        {
            return Ok(_producto.Update(request));
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
            return Ok(_producto.Delete(id));
        }
        #endregion CRUD METHODS


    }
}
