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
    public class BusinessTipoDocumento : IBusinessTipoDocumento
    {
        #region DECLARAR VARIABLE CONSTRUCTORES / DISPOSE
        private readonly IRepositoryTipoDocumento _tipoDocumentoRepository;
        private readonly IMapper _mapper;

        public BusinessTipoDocumento(IMapper mapper)
        {
            _mapper = mapper;
            _tipoDocumentoRepository = new RepositoryTipoDocumento();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion DECLARAR VARIABLE CONSTRUCTORES / DISPOSE

        #region CRUD METHODS
        public ResponseTipoDocumento Create(RequestTipoDocumento entity)
        {
            TipoDocumento tipoDocumentoEntity = _mapper.Map<TipoDocumento>(entity);
            TipoDocumento createdTipoDocumento = _tipoDocumentoRepository.Create(tipoDocumentoEntity);
            return _mapper.Map<ResponseTipoDocumento>(createdTipoDocumento);
        }

        public List<ResponseTipoDocumento> CreateMultiple(List<RequestTipoDocumento> list)
        {
            List<TipoDocumento> tipoDocumentoEntities = _mapper.Map<List<TipoDocumento>>(list);
            List<TipoDocumento> createdTipoDocumentos = _tipoDocumentoRepository.CreateMultiple(tipoDocumentoEntities);
            return _mapper.Map<List<ResponseTipoDocumento>>(createdTipoDocumentos);
        }

        public int Delete(object id)
        {
            return _tipoDocumentoRepository.Delete(id);
        }

        public int DeleteMultiple(List<RequestTipoDocumento> list)
        {
            List<TipoDocumento> tipoDocumentoEntities = _mapper.Map<List<TipoDocumento>>(list);
            return _tipoDocumentoRepository.DeleteMultiple(tipoDocumentoEntities);
        }

        public List<ResponseTipoDocumento> GetAll()
        {
            List<TipoDocumento> tipoDocumentos = _tipoDocumentoRepository.GetAll();
            return _mapper.Map<List<ResponseTipoDocumento>>(tipoDocumentos);
        }

        public ResponseFilterGeneric<ResponseTipoDocumento> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }

        public ResponseTipoDocumento GetById(object id)
        {
            TipoDocumento tipoDocumentoEntity = _tipoDocumentoRepository.GetById(id);
            return _mapper.Map<ResponseTipoDocumento>(tipoDocumentoEntity);
        }

        public ResponseTipoDocumento Update(RequestTipoDocumento entity)
        {
            TipoDocumento tipoDocumentoEntity = _mapper.Map<TipoDocumento>(entity);
            TipoDocumento updatedTipoDocumento = _tipoDocumentoRepository.Update(tipoDocumentoEntity);
            return _mapper.Map<ResponseTipoDocumento>(updatedTipoDocumento);
        }

        public List<ResponseTipoDocumento> UpdateMultiple(List<RequestTipoDocumento> list)
        {
            List<TipoDocumento> tipoDocumentoEntities = _mapper.Map<List<TipoDocumento>>(list);
            List<TipoDocumento> updatedTipoDocumentos = _tipoDocumentoRepository.UpdateMultiple(tipoDocumentoEntities);
            return _mapper.Map<List<ResponseTipoDocumento>>(updatedTipoDocumentos);
        }
        #endregion CRUD METHODS
    }

}
