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
    public class BusinessUnidadMedida : IBusinessUnidadMedida
    {
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IRepositoryUnidadMedida _repositoryUnidadMedida;
        private readonly IMapper _mapper;

        public BusinessUnidadMedida(IMapper mapper)
        {
            _mapper = mapper;
            _repositoryUnidadMedida = new RepositoryUnidadMedida();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region CRUD METHODS

        public List<ResponseUnidadMedida> GetAll()
        {
            List<UnidadMedida> unidadesMedida = _repositoryUnidadMedida.GetAll();
            List<ResponseUnidadMedida> result = _mapper.Map<List<ResponseUnidadMedida>>(unidadesMedida);
            return result;
        }

        public ResponseUnidadMedida GetById(object id)
        {
            UnidadMedida unidadMedida = _repositoryUnidadMedida.GetById(id);
            ResponseUnidadMedida result = _mapper.Map<ResponseUnidadMedida>(unidadMedida);
            return result;
        }

        public ResponseUnidadMedida Create(RequestUnidadMedida entity)
        {
            UnidadMedida unidadMedida = _mapper.Map<UnidadMedida>(entity);
            unidadMedida = _repositoryUnidadMedida.Create(unidadMedida);
            ResponseUnidadMedida result = _mapper.Map<ResponseUnidadMedida>(unidadMedida);
            return result;
        }

        public List<ResponseUnidadMedida> CreateMultiple(List<RequestUnidadMedida> lista)
        {
            List<UnidadMedida> unidadesMedida = _mapper.Map<List<UnidadMedida>>(lista);
            unidadesMedida = _repositoryUnidadMedida.CreateMultiple(unidadesMedida);
            List<ResponseUnidadMedida> result = _mapper.Map<List<ResponseUnidadMedida>>(unidadesMedida);
            return result;
        }

        public ResponseUnidadMedida Update(RequestUnidadMedida entity)
        {
            UnidadMedida unidadMedida = _mapper.Map<UnidadMedida>(entity);
            unidadMedida = _repositoryUnidadMedida.Update(unidadMedida);
            ResponseUnidadMedida result = _mapper.Map<ResponseUnidadMedida>(unidadMedida);
            return result;
        }

        public List<ResponseUnidadMedida> UpdateMultiple(List<RequestUnidadMedida> lista)
        {
            List<UnidadMedida> unidadesMedida = _mapper.Map<List<UnidadMedida>>(lista);
            unidadesMedida = _repositoryUnidadMedida.UpdateMultiple(unidadesMedida);
            List<ResponseUnidadMedida> response = _mapper.Map<List<ResponseUnidadMedida>>(unidadesMedida);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _repositoryUnidadMedida.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestUnidadMedida> lista)
        {
            List<UnidadMedida> unidadesMedida = _mapper.Map<List<UnidadMedida>>(lista);
            int cantidad = _repositoryUnidadMedida.DeleteMultiple(unidadesMedida);
            return cantidad;
        }

        public ResponseFilterGeneric<ResponseUnidadMedida> GetByFilter(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseUnidadMedida> result = _mapper.Map<ResponseFilterGeneric<ResponseUnidadMedida>>(_repositoryUnidadMedida.GetByFilter(request));
            return result;
        }

        #endregion CRUD METHODS

    }

}
