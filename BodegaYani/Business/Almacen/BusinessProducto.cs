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
    public class BusinessProducto : IBusinessProducto
    {
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IRepositoryProducto _repositoryProducto;
        private readonly IMapper _mapper;

        public BusinessProducto(IMapper mapper)
        {
            _mapper = mapper;
            _repositoryProducto = new RepositoryProducto();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region CRUD METHODS

        public List<ResponseProducto> GetAll()
        {
            List<Producto> productos = _repositoryProducto.GetAll();
            List<ResponseProducto> result = _mapper.Map<List<ResponseProducto>>(productos);
            return result;
        }

        public ResponseProducto GetById(object id)
        {
            Producto producto = _repositoryProducto.GetById(id);
            ResponseProducto result = _mapper.Map<ResponseProducto>(producto);
            return result;
        }

        public ResponseProducto Create(RequestProducto entity)
        {
            Producto producto = _mapper.Map<Producto>(entity);
            producto = _repositoryProducto.Create(producto);
            ResponseProducto result = _mapper.Map<ResponseProducto>(producto);
            return result;
        }

        public List<ResponseProducto> CreateMultiple(List<RequestProducto> lista)
        {
            List<Producto> productos = _mapper.Map<List<Producto>>(lista);
            productos = _repositoryProducto.CreateMultiple(productos);
            List<ResponseProducto> result = _mapper.Map<List<ResponseProducto>>(productos);
            return result;
        }

        public ResponseProducto Update(RequestProducto entity)
        {
            Producto producto = _mapper.Map<Producto>(entity);
            producto = _repositoryProducto.Update(producto);
            ResponseProducto result = _mapper.Map<ResponseProducto>(producto);
            return result;
        }

        public List<ResponseProducto> UpdateMultiple(List<RequestProducto> lista)
        {
            List<Producto> productos = _mapper.Map<List<Producto>>(lista);
            productos = _repositoryProducto.UpdateMultiple(productos);
            List<ResponseProducto> response = _mapper.Map<List<ResponseProducto>>(productos);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _repositoryProducto.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestProducto> lista)
        {
            List<Producto> productos = _mapper.Map<List<Producto>>(lista);
            int cantidad = _repositoryProducto.DeleteMultiple(productos);
            return cantidad;
        }

        public ResponseFilterGeneric<ResponseProducto> GetByFilter(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseProducto> result = _mapper.Map<ResponseFilterGeneric<ResponseProducto>>(_repositoryProducto.GetByFilter(request));
            return result;
        }

        public ResponseFilterGeneric<Vproducto> GetByFilterView(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<Vproducto> result = _mapper.Map<ResponseFilterGeneric<Vproducto>>(_repositoryProducto.GetByFilterView(request));
            return result;
        }

        #endregion CRUD METHODS

    }

}
