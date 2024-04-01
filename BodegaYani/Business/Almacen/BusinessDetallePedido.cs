using AutoMapper;
using DBBodegaYani.BodegaYani;
using IBusiness.Almacen;
using IRepository.Almacen;
using Repository.Almacen;
using RequestResponseModels.Generic;
using RequestResponseModels.Request.Almacen;
using RequestResponseModels.Response.Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Almacen
{
    public class BusinessDetallePedido : IBusinessDetallePedido
    {
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IRepositoryDetallePedido _detallePedidoRepository;
        private readonly IMapper _mapper;

        public BusinessDetallePedido(IMapper mapper)
        {
            _mapper = mapper;
            _detallePedidoRepository = new RepositoryDetallePedido();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region CRUD METHODS

        public List<ResponseDetallePedido> GetAll()
        {
            List<DetallePedido> detallesPedidos = _detallePedidoRepository.GetAll();
            List<ResponseDetallePedido> result = _mapper.Map<List<ResponseDetallePedido>>(detallesPedidos);
            return result;
        }

        public ResponseDetallePedido GetById(object id)
        {
            DetallePedido detallePedido = _detallePedidoRepository.GetById(id);
            ResponseDetallePedido result = _mapper.Map<ResponseDetallePedido>(detallePedido);
            return result;
        }

        public ResponseDetallePedido Create(RequestDetallePedido entity)
        {
            DetallePedido detallePedido = _mapper.Map<DetallePedido>(entity);
            detallePedido = _detallePedidoRepository.Create(detallePedido);
            ResponseDetallePedido result = _mapper.Map<ResponseDetallePedido>(detallePedido);
            return result;
        }

        public List<ResponseDetallePedido> CreateMultiple(List<RequestDetallePedido> lista)
        {
            List<DetallePedido> detallesPedidos = _mapper.Map<List<DetallePedido>>(lista);
            detallesPedidos = _detallePedidoRepository.CreateMultiple(detallesPedidos);
            List<ResponseDetallePedido> result = _mapper.Map<List<ResponseDetallePedido>>(detallesPedidos);
            return result;
        }

        public ResponseDetallePedido Update(RequestDetallePedido entity)
        {
            DetallePedido detallePedido = _mapper.Map<DetallePedido>(entity);
            detallePedido = _detallePedidoRepository.Update(detallePedido);
            ResponseDetallePedido result = _mapper.Map<ResponseDetallePedido>(detallePedido);
            return result;
        }

        public List<ResponseDetallePedido> UpdateMultiple(List<RequestDetallePedido> lista)
        {
            List<DetallePedido> detallesPedidos = _mapper.Map<List<DetallePedido>>(lista);
            detallesPedidos = _detallePedidoRepository.UpdateMultiple(detallesPedidos);
            List<ResponseDetallePedido> response = _mapper.Map<List<ResponseDetallePedido>>(detallesPedidos);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _detallePedidoRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestDetallePedido> lista)
        {
            List<DetallePedido> detallesPedidos = _mapper.Map<List<DetallePedido>>(lista);
            int cantidad = _detallePedidoRepository.DeleteMultiple(detallesPedidos);
            return cantidad;
        }

        public ResponseFilterGeneric<ResponseDetallePedido> GetByFilter(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseDetallePedido> result = _mapper.Map<ResponseFilterGeneric<ResponseDetallePedido>>(_detallePedidoRepository.GetByFilter(request));
            return result;
        }

        #endregion CRUD METHODS

    }


}
