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
        #region DECLARAR VARIABLE CONSTRUCTORES / DISPOSE
        private readonly IRepositoryUnidadMedida _unidadMedidaRepository;
        private readonly IMapper _mapper;

        public BusinessUnidadMedida(IMapper mapper)
        {
            _mapper = mapper;
            _unidadMedidaRepository = new RepositoryUnidadMedida();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion DECLARAR VARIABLE CONSTRUCTORES / DISPOSE

        #region CRUD METHODS
        public ResponseUnidadMedida Create(RequestUnidadMedida entity)
        {
            UnidadMedida unidadMedidaEntity = _mapper.Map<UnidadMedida>(entity);
            UnidadMedida createdUnidadMedida = _unidadMedidaRepository.Create(unidadMedidaEntity);
            return _mapper.Map<ResponseUnidadMedida>(createdUnidadMedida);
        }

        public List<ResponseUnidadMedida> CreateMultiple(List<RequestUnidadMedida> list)
        {
            List<UnidadMedida> unidadMedidaEntities = _mapper.Map<List<UnidadMedida>>(list);
            List<UnidadMedida> createdUnidadMedidas = _unidadMedidaRepository.CreateMultiple(unidadMedidaEntities);
            return _mapper.Map<List<ResponseUnidadMedida>>(createdUnidadMedidas);
        }

        public int Delete(object id)
        {
            return _unidadMedidaRepository.Delete(id);
        }

        public int DeleteMultiple(List<RequestUnidadMedida> list)
        {
            List<UnidadMedida> unidadMedidaEntities = _mapper.Map<List<UnidadMedida>>(list);
            return _unidadMedidaRepository.DeleteMultiple(unidadMedidaEntities);
        }

        public List<ResponseUnidadMedida> GetAll()
        {
            List<UnidadMedida> unidadMedidas = _unidadMedidaRepository.GetAll();
            return _mapper.Map<List<ResponseUnidadMedida>>(unidadMedidas);
        }

        public ResponseFilterGeneric<ResponseUnidadMedida> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }

        public ResponseUnidadMedida GetById(object id)
        {
            UnidadMedida unidadMedidaEntity = _unidadMedidaRepository.GetById(id);
            return _mapper.Map<ResponseUnidadMedida>(unidadMedidaEntity);
        }

        public ResponseUnidadMedida Update(RequestUnidadMedida entity)
        {
            UnidadMedida unidadMedidaEntity = _mapper.Map<UnidadMedida>(entity);
            UnidadMedida updatedUnidadMedida = _unidadMedidaRepository.Update(unidadMedidaEntity);
            return _mapper.Map<ResponseUnidadMedida>(updatedUnidadMedida);
        }

        public List<ResponseUnidadMedida> UpdateMultiple(List<RequestUnidadMedida> list)
        {
            List<UnidadMedida> unidadMedidaEntities = _mapper.Map<List<UnidadMedida>>(list);
            List<UnidadMedida> updatedUnidadMedidas = _unidadMedidaRepository.UpdateMultiple(unidadMedidaEntities);
            return _mapper.Map<List<ResponseUnidadMedida>>(updatedUnidadMedidas);
        }
        #endregion CRUD METHODS
    }

}
