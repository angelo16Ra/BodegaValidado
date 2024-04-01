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
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IRepositoryTipoDocumento _repositoryTipoDocumento;
        private readonly IMapper _mapper;

        public BusinessTipoDocumento(IMapper mapper)
        {
            _mapper = mapper;
            _repositoryTipoDocumento = new RepositoryTipoDocumento();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region CRUD METHODS

        public List<ResponseTipoDocumento> GetAll()
        {
            List<TipoDocumento> tiposDocumento = _repositoryTipoDocumento.GetAll();
            List<ResponseTipoDocumento> result = _mapper.Map<List<ResponseTipoDocumento>>(tiposDocumento);
            return result;
        }

        public ResponseTipoDocumento GetById(object id)
        {
            TipoDocumento tipoDocumento = _repositoryTipoDocumento.GetById(id);
            ResponseTipoDocumento result = _mapper.Map<ResponseTipoDocumento>(tipoDocumento);
            return result;
        }

        public ResponseTipoDocumento Create(RequestTipoDocumento entity)
        {
            TipoDocumento tipoDocumento = _mapper.Map<TipoDocumento>(entity);
            tipoDocumento = _repositoryTipoDocumento.Create(tipoDocumento);
            ResponseTipoDocumento result = _mapper.Map<ResponseTipoDocumento>(tipoDocumento);
            return result;
        }

        public List<ResponseTipoDocumento> CreateMultiple(List<RequestTipoDocumento> lista)
        {
            List<TipoDocumento> tiposDocumento = _mapper.Map<List<TipoDocumento>>(lista);
            tiposDocumento = _repositoryTipoDocumento.CreateMultiple(tiposDocumento);
            List<ResponseTipoDocumento> result = _mapper.Map<List<ResponseTipoDocumento>>(tiposDocumento);
            return result;
        }

        public ResponseTipoDocumento Update(RequestTipoDocumento entity)
        {
            TipoDocumento tipoDocumento = _mapper.Map<TipoDocumento>(entity);
            tipoDocumento = _repositoryTipoDocumento.Update(tipoDocumento);
            ResponseTipoDocumento result = _mapper.Map<ResponseTipoDocumento>(tipoDocumento);
            return result;
        }

        public List<ResponseTipoDocumento> UpdateMultiple(List<RequestTipoDocumento> lista)
        {
            List<TipoDocumento> tiposDocumento = _mapper.Map<List<TipoDocumento>>(lista);
            tiposDocumento = _repositoryTipoDocumento.UpdateMultiple(tiposDocumento);
            List<ResponseTipoDocumento> response = _mapper.Map<List<ResponseTipoDocumento>>(tiposDocumento);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _repositoryTipoDocumento.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestTipoDocumento> lista)
        {
            List<TipoDocumento> tiposDocumento = _mapper.Map<List<TipoDocumento>>(lista);
            int cantidad = _repositoryTipoDocumento.DeleteMultiple(tiposDocumento);
            return cantidad;
        }

        public ResponseFilterGeneric<ResponseTipoDocumento> GetByFilter(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseTipoDocumento> result = _mapper.Map<ResponseFilterGeneric<ResponseTipoDocumento>>(_repositoryTipoDocumento.GetByFilter(request));
            return result;
        }

        #endregion CRUD METHODS

    }

}
