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

        public List<ResponseRol> GetAll()
        {
            List<Rol> roles = _rol.GetAll();
            List<ResponseRol> result = _mapper.Map<List<ResponseRol>>(roles);
            return result;
        }

        public ResponseRol GetById(object id)
        {
            Rol roles = _rol.GetById(id);
            ResponseRol result = _mapper.Map<ResponseRol>(roles);
            return result;
        }

        public ResponseRol Create(RequestRol entity)
        {
            Rol roles = _mapper.Map<Rol>(entity);
            roles = _rol.Create(roles);
            ResponseRol result = _mapper.Map<ResponseRol>(roles);
            return result;
        }

        public List<ResponseRol> CreateMultiple(List<RequestRol> lista)
        {
            List<Rol> roles = _mapper.Map<List<Rol>>(lista);
            roles = _rol.CreateMultiple(roles);
            List<ResponseRol> result = _mapper.Map<List<ResponseRol>>(roles);
            return result;
        }

        public ResponseRol Update(RequestRol entity)
        {
            Rol roles = _mapper.Map<Rol>(entity);
            roles = _rol.Update(roles);
            ResponseRol result = _mapper.Map<ResponseRol>(roles);
            return result;
        }

        public List<ResponseRol> UpdateMultiple(List<RequestRol> lista)
        {
            List<Rol> roles = _mapper.Map<List<Rol>>(lista);
            roles = _rol.UpdateMultiple(roles);
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

        public ResponseFilterGeneric<ResponseRol> GetByFilter(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseRol> result = _mapper.Map<ResponseFilterGeneric<ResponseRol>>(_rol.GetByFilter(request));

            return result;
        }
        #endregion CRUD METHODS

    }


}
