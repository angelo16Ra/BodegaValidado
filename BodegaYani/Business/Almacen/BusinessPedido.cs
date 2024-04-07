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
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
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

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region CRUD METHODS

        public List<ResponsePedido> GetAll()
        {
            List<Pedido> pedidos = _pedidoRepository.GetAll();
            List<ResponsePedido> result = _mapper.Map<List<ResponsePedido>>(pedidos);
            return result;
        }

        public ResponsePedido GetById(object id)
        {
            Pedido pedido = _pedidoRepository.GetById(id);
            ResponsePedido result = _mapper.Map<ResponsePedido>(pedido);
            return result;
        }

        public ResponsePedido Create(RequestPedido entity)
        {
            Pedido pedido = _mapper.Map<Pedido>(entity);
            pedido = _pedidoRepository.Create(pedido);
            ResponsePedido result = _mapper.Map<ResponsePedido>(pedido);
            return result;
        }

        public List<ResponsePedido> CreateMultiple(List<RequestPedido> lista)
        {
            List<Pedido> pedidos = _mapper.Map<List<Pedido>>(lista);
            pedidos = _pedidoRepository.CreateMultiple(pedidos);
            List<ResponsePedido> result = _mapper.Map<List<ResponsePedido>>(pedidos);
            return result;
        }

        public ResponsePedido Update(RequestPedido entity)
        {
            Pedido pedido = _mapper.Map<Pedido>(entity);
            pedido = _pedidoRepository.Update(pedido);
            ResponsePedido result = _mapper.Map<ResponsePedido>(pedido);
            return result;
        }

        public List<ResponsePedido> UpdateMultiple(List<RequestPedido> lista)
        {
            List<Pedido> pedidos = _mapper.Map<List<Pedido>>(lista);
            pedidos = _pedidoRepository.UpdateMultiple(pedidos);
            List<ResponsePedido> response = _mapper.Map<List<ResponsePedido>>(pedidos);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _pedidoRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestPedido> lista)
        {
            List<Pedido> pedidos = _mapper.Map<List<Pedido>>(lista);
            int cantidad = _pedidoRepository.DeleteMultiple(pedidos);
            return cantidad;
        }

        public ResponseFilterGeneric<ResponsePedido> GetByFilter(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponsePedido> result = _mapper.Map<ResponseFilterGeneric<ResponsePedido>>(_pedidoRepository.GetByFilter(request));
            return result;
        }

        public ResponseFilterGeneric<Vpedido> GetByFilterView(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<Vpedido> result = _mapper.Map<ResponseFilterGeneric<Vpedido>>(_pedidoRepository.GetByFilterView(request));
            return result;
        }

        #endregion CRUD METHODS

    }

}
