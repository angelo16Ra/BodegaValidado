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
        #region DECLARAR VARIABLE CONSTRUCTORES / DISPOSE
        private readonly IRepositoryProveedore _Proveedore;
        private readonly IMapper _mapper;
        public BusinessProveedor(IMapper mapper)
        {
            _mapper = mapper;
            _Proveedore = new RepositoryProveedore();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARAR VARIABLE CONSTRUCTORES / DISPOSE

        #region CRUD METHODS
        public ResponseProveedor Create(RequestProveedor entity)
        {
            Proveedore Proveedores = _mapper.Map<Proveedore>(entity);
            Proveedores = _Proveedore.Create(Proveedores);
            ResponseProveedor response = _mapper.Map<ResponseProveedor>(Proveedores);
            return response;
        }

        public List<ResponseProveedor> CreateMultiple(List<RequestProveedor> lista)
        {
            List<Proveedore> Proveedores = _mapper.Map<List<Proveedore>>(lista);
            Proveedores = _Proveedore.CreateMultiple(Proveedores);
            List<ResponseProveedor> response = _mapper.Map<List<ResponseProveedor>>(Proveedores);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _Proveedore.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestProveedor> lista)
        {
            List<Proveedore> Proveedores = _mapper.Map<List<Proveedore>>(lista);
            int cantidad = _Proveedore.DeleteMultiple(Proveedores);
            return cantidad;
        }

        public List<ResponseProveedor> GetAll()
        {
            List<Proveedore> Proveedores = _Proveedore.GetAll();
            List<ResponseProveedor> response = _mapper.Map<List<ResponseProveedor>>(Proveedores);
            return response;
        }

        public ResponseFilterGeneric<ResponseProveedor> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }

        public ResponseProveedor GetById(object id)
        {
            Proveedore Proveedores = _Proveedore.GetById(id);
            ResponseProveedor response = _mapper.Map<ResponseProveedor>(Proveedores);
            return response;
        }

        public ResponseProveedor Update(RequestProveedor entity)
        {
            Proveedore Proveedores = _mapper.Map<Proveedore>(entity);
            Proveedores = _Proveedore.Update(Proveedores);
            ResponseProveedor response = _mapper.Map<ResponseProveedor>(Proveedores);
            return response;
        }

        public List<ResponseProveedor> UpdateMultiple(List<RequestProveedor> lista)
        {
            List<Proveedore> Proveedores = _mapper.Map<List<Proveedore>>(lista);
            Proveedores = _Proveedore.UpdateMultiple(Proveedores);
            List<ResponseProveedor> response = _mapper.Map<List<ResponseProveedor>>(Proveedores);
            return response;
        }
        #endregion CRUD METHODS
    }
}
