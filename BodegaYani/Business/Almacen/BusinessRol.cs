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
    public class BusinessRol : IBusinessRol
    {
        #region DECLARAR VARIABLE CONSTRUCTORES / DISPOSE
        private readonly IRepositoryRol _rol;
        private readonly IMapper _mapper;

        public BusinessRol(IMapper mapper)
        {
            _mapper = mapper;
            _rol = new RepositoryRol();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARAR VARIABLE CONSTRUCTORES / DISPOSE

        #region CRUD METHODS
        public ResponseRol Create(RequestRol entity)
        {
            Rol roles = _mapper.Map<Rol>(entity);
            roles = _rol.Create(roles);
            ResponseRol response = _mapper.Map<ResponseRol>(roles);
            return response;
        }

        public List<ResponseRol> CreateMultiple(List<RequestRol> lista)
        {
            List<Rol> roles = _mapper.Map<List<Rol>>(lista);
            roles = _rol.CreateMultiple(roles);
            List<ResponseRol> response = _mapper.Map<List<ResponseRol>>(roles);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _rol.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestRol> lista)
        {
            List<Rol> roles = _mapper.Map<List<Rol>>(lista);
            int cantidad = _rol.DeleteMultiple(roles);
            return cantidad;
        }

        public List<ResponseRol> GetAll()
        {
            List<Rol> roles = _rol.GetAll();
            List<ResponseRol> response = _mapper.Map<List<ResponseRol>>(roles);
            return response;
        }

        public ResponseFilterGeneric<ResponseRol> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }

        public ResponseRol GetById(object id)
        {
            Rol roles = _rol.GetById(id);
            ResponseRol response = _mapper.Map<ResponseRol>(roles);
            return response;
        }

        public ResponseRol Update(RequestRol entity)
        {
            Rol roles = _mapper.Map<Rol>(entity);
            roles = _rol.Update(roles);
            ResponseRol response = _mapper.Map<ResponseRol>(roles);
            return response;
        }

        public List<ResponseRol> UpdateMultiple(List<RequestRol> lista)
        {
            List<Rol> roles = _mapper.Map<List<Rol>>(lista);
            roles = _rol.UpdateMultiple(roles);
            List<ResponseRol> response = _mapper.Map<List<ResponseRol>>(roles);
            return response;
        }
        #endregion CRUD METHODS

    }


}
