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
        #region DECLARAR VARIABLE CONSTRUCTORES / DISPOSE
        private readonly IRepositoryProducto _productoRepository;
        private readonly IMapper _mapper;

        public BusinessProducto(IMapper mapper)
        {
            _mapper = mapper;
            _productoRepository = new RepositoryProducto();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion DECLARAR VARIABLE CONSTRUCTORES / DISPOSE

        #region CRUD METHODS
        public ResponseProducto Create(RequestProducto entity)
        {
            Producto productoEntity = _mapper.Map<Producto>(entity);
            Producto createdProducto = _productoRepository.Create(productoEntity);
            return _mapper.Map<ResponseProducto>(createdProducto);
        }

        public List<ResponseProducto> CreateMultiple(List<RequestProducto> list)
        {
            List<Producto> productoEntities = _mapper.Map<List<Producto>>(list);
            List<Producto> createdProductos = _productoRepository.CreateMultiple(productoEntities);
            return _mapper.Map<List<ResponseProducto>>(createdProductos);
        }

        public int Delete(object id)
        {
            return _productoRepository.Delete(id);
        }

        public int DeleteMultiple(List<RequestProducto> list)
        {
            List<Producto> productoEntities = _mapper.Map<List<Producto>>(list);
            return _productoRepository.DeleteMultiple(productoEntities);
        }

        public List<ResponseProducto> GetAll()
        {
            List<Producto> productos = _productoRepository.GetAll();
            return _mapper.Map<List<ResponseProducto>>(productos);
        }

        public ResponseFilterGeneric<ResponseProducto> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }

        public ResponseProducto GetById(object id)
        {
            Producto productoEntity = _productoRepository.GetById(id);
            return _mapper.Map<ResponseProducto>(productoEntity);
        }

        public ResponseProducto Update(RequestProducto entity)
        {
            Producto productoEntity = _mapper.Map<Producto>(entity);
            Producto updatedProducto = _productoRepository.Update(productoEntity);
            return _mapper.Map<ResponseProducto>(updatedProducto);
        }

        public List<ResponseProducto> UpdateMultiple(List<RequestProducto> list)
        {
            List<Producto> productoEntities = _mapper.Map<List<Producto>>(list);
            List<Producto> updatedProductos = _productoRepository.UpdateMultiple(productoEntities);
            return _mapper.Map<List<ResponseProducto>>(updatedProductos);
        }
        #endregion CRUD METHODS
    }

}
