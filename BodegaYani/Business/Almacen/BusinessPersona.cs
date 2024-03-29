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
        #region DECLARAR VARIABLE CONSTRUCTORES / DISPOSE
        private readonly IRepositoryPersona _persona;
        private readonly IMapper _mapper;

        public BusinessPersona(IMapper mapper)
        {
            _mapper = mapper;
            _persona = new RepositoryPersona();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARAR VARIABLE CONSTRUCTORES / DISPOSE

        #region CRUD METHODS
        public ResponsePersona Create(RequestPersona entity)
        {
            Persona personas = _mapper.Map<Persona>(entity);
            personas = _persona.Create(personas);
            ResponsePersona response = _mapper.Map<ResponsePersona>(personas);
            return response;
        }

        public List<ResponsePersona> CreateMultiple(List<RequestPersona> lista)
        {
            List<Persona> personas = _mapper.Map<List<Persona>>(lista);
            personas = _persona.CreateMultiple(personas);
            List<ResponsePersona> response = _mapper.Map<List<ResponsePersona>>(personas);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _persona.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestPersona> lista)
        {
            List<Persona> personas = _mapper.Map<List<Persona>>(lista);
            int cantidad = _persona.DeleteMultiple(personas);
            return cantidad;
        }

        public List<ResponsePersona> GetAll()
        {
            List<Persona> personas = _persona.GetAll();
            List<ResponsePersona> response = _mapper.Map<List<ResponsePersona>>(personas);
            return response;
        }

        public ResponseFilterGeneric<ResponsePersona> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }

        public ResponsePersona GetById(object id)
        {
            Persona personas = _persona.GetById(id);
            ResponsePersona response = _mapper.Map<ResponsePersona>(personas);
            return response;
        }

        public ResponsePersona Update(RequestPersona entity)
        {
            Persona personas = _mapper.Map<Persona>(entity);
            personas = _persona.Update(personas);
            ResponsePersona response = _mapper.Map<ResponsePersona>(personas);
            return response;
        }

        public List<ResponsePersona> UpdateMultiple(List<RequestPersona> lista)
        {
            List<Persona> personas = _mapper.Map<List<Persona>>(lista);
            personas = _persona.UpdateMultiple(personas);
            List<ResponsePersona> response = _mapper.Map<List<ResponsePersona>>(personas);
            return response;
        }

        #endregion CRUD METHODS
    }


}
