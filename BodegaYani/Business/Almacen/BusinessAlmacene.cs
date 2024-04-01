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

        public List<ResponseAlmacene> GetAll()
        {
            List<Almacene> almacenes = _almaceneRepository.GetAll();
            List<ResponseAlmacene> result = _mapper.Map<List<ResponseAlmacene>>(almacenes);
            return result;
        }

        public ResponseAlmacene GetById(object id)
        {
            Almacene almacene = _almaceneRepository.GetById(id);
            ResponseAlmacene result = _mapper.Map<ResponseAlmacene>(almacene);
            return result;
        }

        public ResponseAlmacene Create(RequestAlmacene entity)
        {
            Almacene almacene = _mapper.Map<Almacene>(entity);
            almacene = _almaceneRepository.Create(almacene);
            ResponseAlmacene result = _mapper.Map<ResponseAlmacene>(almacene);
            return result;
        }

        public List<ResponseAlmacene> CreateMultiple(List<RequestAlmacene> lista)
        {
            List<Almacene> almacenes = _mapper.Map<List<Almacene>>(lista);
            almacenes = _almaceneRepository.CreateMultiple(almacenes);
            List<ResponseAlmacene> result = _mapper.Map<List<ResponseAlmacene>>(almacenes);
            return result;
        }

        public ResponseAlmacene Update(RequestAlmacene entity)
        {
            Almacene almacene = _mapper.Map<Almacene>(entity);
            almacene = _almaceneRepository.Update(almacene);
            ResponseAlmacene result = _mapper.Map<ResponseAlmacene>(almacene);
            return result;
        }

        public List<ResponseAlmacene> UpdateMultiple(List<RequestAlmacene> lista)
        {
            List<Almacene> almacenes = _mapper.Map<List<Almacene>>(lista);
            almacenes = _almaceneRepository.UpdateMultiple(almacenes);
            List<ResponseAlmacene> response = _mapper.Map<List<ResponseAlmacene>>(almacenes);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _almaceneRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestAlmacene> lista)
        {
            List<Almacene> almacenes = _mapper.Map<List<Almacene>>(lista);
            int cantidad = _almaceneRepository.DeleteMultiple(almacenes);
            return cantidad;
        }

        public ResponseFilterGeneric<ResponseAlmacene> GetByFilter(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseAlmacene> result = _mapper.Map<ResponseFilterGeneric<ResponseAlmacene>>(_almaceneRepository.GetByFilter(request));
            return result;
        }

        #endregion CRUD METHODS


    }

}
