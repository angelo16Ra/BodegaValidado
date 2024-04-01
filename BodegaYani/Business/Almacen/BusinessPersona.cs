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
    public class BusinessPersona : IBusinessPersona
    {
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IRepositoryPersona _repositoryPersona;
        private readonly IMapper _mapper;

        public BusinessPersona(IMapper mapper)
        {
            _mapper = mapper;
            _repositoryPersona = new RepositoryPersona();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region CRUD METHODS

        public List<ResponsePersona> GetAll()
        {
            List<Persona> personas = _repositoryPersona.GetAll();
            List<ResponsePersona> result = _mapper.Map<List<ResponsePersona>>(personas);
            return result;
        }

        public ResponsePersona GetById(object id)
        {
            Persona persona = _repositoryPersona.GetById(id);
            ResponsePersona result = _mapper.Map<ResponsePersona>(persona);
            return result;
        }

        public ResponsePersona Create(RequestPersona entity)
        {
            Persona persona = _mapper.Map<Persona>(entity);
            persona = _repositoryPersona.Create(persona);
            ResponsePersona result = _mapper.Map<ResponsePersona>(persona);
            return result;
        }

        public List<ResponsePersona> CreateMultiple(List<RequestPersona> lista)
        {
            List<Persona> personas = _mapper.Map<List<Persona>>(lista);
            personas = _repositoryPersona.CreateMultiple(personas);
            List<ResponsePersona> result = _mapper.Map<List<ResponsePersona>>(personas);
            return result;
        }

        public ResponsePersona Update(RequestPersona entity)
        {
            Persona persona = _mapper.Map<Persona>(entity);
            persona = _repositoryPersona.Update(persona);
            ResponsePersona result = _mapper.Map<ResponsePersona>(persona);
            return result;
        }

        public List<ResponsePersona> UpdateMultiple(List<RequestPersona> lista)
        {
            List<Persona> personas = _mapper.Map<List<Persona>>(lista);
            personas = _repositoryPersona.UpdateMultiple(personas);
            List<ResponsePersona> response = _mapper.Map<List<ResponsePersona>>(personas);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _repositoryPersona.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestPersona> lista)
        {
            List<Persona> personas = _mapper.Map<List<Persona>>(lista);
            int cantidad = _repositoryPersona.DeleteMultiple(personas);
            return cantidad;    
        }

        public ResponseFilterGeneric<ResponsePersona> GetByFilter(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponsePersona> result = _mapper.Map<ResponseFilterGeneric<ResponsePersona>>(_repositoryPersona.GetByFilter(request));
            return result;
        }

        #endregion CRUD METHODS

    }


}
