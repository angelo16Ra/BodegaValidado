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
    public class BusinessAlmacene : IBusinessAlmacene
    {
        #region DECLARAR VARIABLE CONSTRUCTORES / DISPOSE
        private readonly IRepositoryAlmacene _almaceneRepository;
        private readonly IMapper _mapper;

        public BusinessAlmacene(IMapper mapper)
        {
            _mapper = mapper;
            _almaceneRepository = new RepositoryAlmacene();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion DECLARAR VARIABLE CONSTRUCTORES / DISPOSE

        #region CRUD METHODS
        public ResponseAlmacene Create(RequestAlmacene entity)
        {
            Almacene almaceneEntity = _mapper.Map<Almacene>(entity);
            Almacene createdAlmacene = _almaceneRepository.Create(almaceneEntity);
            return _mapper.Map<ResponseAlmacene>(createdAlmacene);
        }

        public List<ResponseAlmacene> CreateMultiple(List<RequestAlmacene> list)
        {
            List<Almacene> almaceneEntities = _mapper.Map<List<Almacene>>(list);
            List<Almacene> createdAlmacenes = _almaceneRepository.CreateMultiple(almaceneEntities);
            return _mapper.Map<List<ResponseAlmacene>>(createdAlmacenes);
        }

        public int Delete(object id)
        {
            return _almaceneRepository.Delete(id);
        }

        public int DeleteMultiple(List<RequestAlmacene> list)
        {
            List<Almacene> almaceneEntities = _mapper.Map<List<Almacene>>(list);
            return _almaceneRepository.DeleteMultiple(almaceneEntities);
        }
        

        public List<ResponseAlmacene> GetAll()
        {
            List<Almacene> almacenes = _almaceneRepository.GetAll();
            return _mapper.Map<List<ResponseAlmacene>>(almacenes);
        }

        public ResponseFilterGeneric<ResponseAlmacene> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }

        public ResponseAlmacene GetById(object id)
        {
            Almacene almaceneEntity = _almaceneRepository.GetById(id);
            return _mapper.Map<ResponseAlmacene>(almaceneEntity);
        }

        public ResponseAlmacene Update(RequestAlmacene entity)
        {
            Almacene almaceneEntity = _mapper.Map<Almacene>(entity);
            Almacene updatedAlmacene = _almaceneRepository.Update(almaceneEntity);
            return _mapper.Map<ResponseAlmacene>(updatedAlmacene);
        }

        public List<ResponseAlmacene> UpdateMultiple(List<RequestAlmacene> list)
        {
            List<Almacene> almaceneEntities = _mapper.Map<List<Almacene>>(list);
            List<Almacene> updatedAlmacenes = _almaceneRepository.UpdateMultiple(almaceneEntities);
            return _mapper.Map<List<ResponseAlmacene>>(updatedAlmacenes);
        }
        #endregion CRUD METHODS
    }

}
