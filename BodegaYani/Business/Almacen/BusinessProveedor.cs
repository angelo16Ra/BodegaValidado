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
    public class BusinessProveedor: IBusinessProveedor
    {
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IRepositoryProveedore _repositoryProveedor;
        private readonly IMapper _mapper;

        public BusinessProveedor(IMapper mapper)
        {
            _mapper = mapper;
            _repositoryProveedor = new RepositoryProveedore();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region CRUD METHODS

        public List<ResponseProveedor> GetAll()
        {
            List<Proveedore> proveedores = _repositoryProveedor.GetAll();
            List<ResponseProveedor> result = _mapper.Map<List<ResponseProveedor>>(proveedores);
            return result;
        }

        public ResponseProveedor GetById(object id)
        {
            Proveedore proveedor = _repositoryProveedor.GetById(id);
            ResponseProveedor result = _mapper.Map<ResponseProveedor>(proveedor);
            return result;
        }

        public ResponseProveedor Create(RequestProveedor entity)
        {
            Proveedore proveedor = _mapper.Map<Proveedore>(entity);
            proveedor = _repositoryProveedor.Create(proveedor);
            ResponseProveedor result = _mapper.Map<ResponseProveedor>(proveedor);
            return result;
        }

        public List<ResponseProveedor> CreateMultiple(List<RequestProveedor> lista)
        {
            List<Proveedore> proveedores = _mapper.Map<List<Proveedore>>(lista);
            proveedores = _repositoryProveedor.CreateMultiple(proveedores);
            List<ResponseProveedor> result = _mapper.Map<List<ResponseProveedor>>(proveedores);
            return result;
        }

        public ResponseProveedor Update(RequestProveedor entity)
        {
            Proveedore proveedor = _mapper.Map<Proveedore>(entity);
            proveedor = _repositoryProveedor.Update(proveedor);
            ResponseProveedor result = _mapper.Map<ResponseProveedor>(proveedor);
            return result;
        }

        public List<ResponseProveedor> UpdateMultiple(List<RequestProveedor> lista)
        {
            List<Proveedore> proveedores = _mapper.Map<List<Proveedore>>(lista);
            proveedores = _repositoryProveedor.UpdateMultiple(proveedores);
            List<ResponseProveedor> response = _mapper.Map<List<ResponseProveedor>>(proveedores);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _repositoryProveedor.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestProveedor> lista)
        {
            List<Proveedore> proveedores = _mapper.Map<List<Proveedore>>(lista);
            int cantidad = _repositoryProveedor.DeleteMultiple(proveedores);
            return cantidad;
        }

        public ResponseFilterGeneric<ResponseProveedor> GetByFilter(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseProveedor> result = _mapper.Map<ResponseFilterGeneric<ResponseProveedor>>(_repositoryProveedor.GetByFilter(request));
            return result;
        }

        #endregion CRUD METHODS

    }
}
