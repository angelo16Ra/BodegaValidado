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
        #region DECLARAR VARIABLE CONSTRUCTORES / DISPOSE
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
        #endregion DECLARAR VARIABLE CONSTRUCTORES / DISPOSE

        #region CRUD METHODS
        public ResponseDetallePedido Create(RequestDetallePedido entity)
        {
            DetallePedido detallePedidoEntity = _mapper.Map<DetallePedido>(entity);
            DetallePedido createdDetallePedido = _detallePedidoRepository.Create(detallePedidoEntity);
            return _mapper.Map<ResponseDetallePedido>(createdDetallePedido);
        }

        public List<ResponseDetallePedido> CreateMultiple(List<RequestDetallePedido> list)
        {
            List<DetallePedido> detallePedidoEntities = _mapper.Map<List<DetallePedido>>(list);
            List<DetallePedido> createdDetallePedidos = _detallePedidoRepository.CreateMultiple(detallePedidoEntities);
            return _mapper.Map<List<ResponseDetallePedido>>(createdDetallePedidos);
        }

        public int Delete(object id)
        {
            return _detallePedidoRepository.Delete(id);
        }

        public int DeleteMultiple(List<RequestDetallePedido> list)
        {
            List<DetallePedido> detallePedidoEntities = _mapper.Map<List<DetallePedido>>(list);
            return _detallePedidoRepository.DeleteMultiple(detallePedidoEntities);
        }

        public List<ResponseDetallePedido> GetAll()
        {
            List<DetallePedido> detallePedidos = _detallePedidoRepository.GetAll();
            return _mapper.Map<List<ResponseDetallePedido>>(detallePedidos);
        }

        public ResponseFilterGeneric<ResponseDetallePedido> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }

        public ResponseDetallePedido GetById(object id)
        {
            DetallePedido detallePedidoEntity = _detallePedidoRepository.GetById(id);
            return _mapper.Map<ResponseDetallePedido>(detallePedidoEntity);
        }

        public ResponseDetallePedido Update(RequestDetallePedido entity)
        {
            DetallePedido detallePedidoEntity = _mapper.Map<DetallePedido>(entity);
            DetallePedido updatedDetallePedido = _detallePedidoRepository.Update(detallePedidoEntity);
            return _mapper.Map<ResponseDetallePedido>(updatedDetallePedido);
        }

        public List<ResponseDetallePedido> UpdateMultiple(List<RequestDetallePedido> list)
        {
            List<DetallePedido> detallePedidoEntities = _mapper.Map<List<DetallePedido>>(list);
            List<DetallePedido> updatedDetallePedidos = _detallePedidoRepository.UpdateMultiple(detallePedidoEntities);
            return _mapper.Map<List<ResponseDetallePedido>>(updatedDetallePedidos);
        }
        #endregion CRUD METHODS
    }


}
