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
    public class PedidoController : ControllerBase
    {
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IBusinessPedido _pedido;
        private readonly IMapper _mapper;
        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR

        #region constructor
        public PedidoController(IMapper mapper)
        {
            _mapper = mapper;
            _pedido = new BusinessPedido(mapper);
        }
        #endregion constructor

        #region CRUD METHODS

        /// <summary>
        /// RETORNA TODOS LOS REGISTROS DE LA TABLA PEDIDO
        /// </summary>
        /// <returns>List-PedidoResponse</returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ResponsePedido>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            return Ok(_pedido.GetAll());
        }

        /// <summary>
        /// RETORNA EL REGISTRO DE LA TABLA FILTRADO POR EL PRIMARY KEY
        /// </summary>
        /// <param name="id">PRIMARY KEY</param>
        /// <returns>ResponsePedido</returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponsePedido))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get(int id)
        {
            return Ok(_pedido.GetById(id));
        }

        /// <summary>
        /// INSERTA UN REGISTRO EN LA TABLA PEDIDO
        /// </summary>
        /// <param name="request">RequestPedido</param>
        /// <returns>ResponsePedido</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponsePedido))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Create([FromBody] RequestPedido request)
        {
            return Ok(_pedido.Create(request));
        }

        /// <summary>
        /// RETORNA LA TABLA PEDIDO EN BASE A PAGINACIÓN Y FILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public IActionResult GetByFilter([FromBody] RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponsePedido> res = _pedido.GetByFilter(request);

            return Ok(res);
        }

        /// <summary>
        /// RETORNA LA TABLA PEDIDO EN BASE A PAGINACIÓN Y FILTROS
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiple")]
        public IActionResult CreateMultiple([FromBody] List<RequestPedido> request)
        {
            List<ResponsePedido> res = _pedido.CreateMultiple(request);

            return Ok(res);
        }

        /// <summary>
        /// ACTUALIZA UN REGISTRO EN LA TABLA PEDIDO
        /// </summary>
        /// <param name="request">RequestPedido</param>
        /// <returns>ResponsePedido</returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ResponsePedido))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Update([FromBody] RequestPedido request)
        {
            return Ok(_pedido.Update(request));
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
            return Ok(_pedido.Delete(id));
        }
        #endregion CRUD METHODS



    }
}
