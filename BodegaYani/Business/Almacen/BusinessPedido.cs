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
    public class BusinessPedido : IBusinessPedido
    {
        #region DECLARAR VARIABLE CONSTRUCTORES / DISPOSE
        private readonly IRepositoryPedido _pedidoRepository;
        private readonly IMapper _mapper;

        public BusinessPedido(IMapper mapper)
        {
            _mapper = mapper;
            _pedidoRepository = new RepositoryPedido();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion DECLARAR VARIABLE CONSTRUCTORES / DISPOSE

        #region CRUD METHODS
        public ResponsePedido Create(RequestPedido entity)
        {
            Pedido pedidoEntity = _mapper.Map<Pedido>(entity);
            Pedido createdPedido = _pedidoRepository.Create(pedidoEntity);
            return _mapper.Map<ResponsePedido>(createdPedido);
        }

        public List<ResponsePedido> CreateMultiple(List<RequestPedido> list)
        {
            List<Pedido> pedidoEntities = _mapper.Map<List<Pedido>>(list);
            List<Pedido> createdPedidos = _pedidoRepository.CreateMultiple(pedidoEntities);
            return _mapper.Map<List<ResponsePedido>>(createdPedidos);
        }

        public int Delete(object id)
        {
            return _pedidoRepository.Delete(id);
        }

        public int DeleteMultiple(List<RequestPedido> list)
        {
            List<Pedido> pedidoEntities = _mapper.Map<List<Pedido>>(list);
            return _pedidoRepository.DeleteMultiple(pedidoEntities);
        }

        public List<ResponsePedido> GetAll()
        {
            List<Pedido> pedidos = _pedidoRepository.GetAll();
            return _mapper.Map<List<ResponsePedido>>(pedidos);
        }

        public ResponseFilterGeneric<ResponsePedido> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }

        public ResponsePedido GetById(object id)
        {
            Pedido pedidoEntity = _pedidoRepository.GetById(id);
            return _mapper.Map<ResponsePedido>(pedidoEntity);
        }

        public ResponsePedido Update(RequestPedido entity)
        {
            Pedido pedidoEntity = _mapper.Map<Pedido>(entity);
            Pedido updatedPedido = _pedidoRepository.Update(pedidoEntity);
            return _mapper.Map<ResponsePedido>(updatedPedido);
        }

        public List<ResponsePedido> UpdateMultiple(List<RequestPedido> list)
        {
            List<Pedido> pedidoEntities = _mapper.Map<List<Pedido>>(list);
            List<Pedido> updatedPedidos = _pedidoRepository.UpdateMultiple(pedidoEntities);
            return _mapper.Map<List<ResponsePedido>>(updatedPedidos);
        }
        #endregion CRUD METHODS
    }

}
