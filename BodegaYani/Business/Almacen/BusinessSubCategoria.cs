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
    public class BusinessSubCategoria : IBusinessSubCategoria
    {
        #region DECLARAR VARIABLE CONSTRUCTORES / DISPOSE
        private readonly IRepositorySubCategoria _subCategoriaRepository;
        private readonly IMapper _mapper;

        public BusinessSubCategoria(IMapper mapper)
        {
            _mapper = mapper;
            _subCategoriaRepository = new RepositorySubCategoria();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion DECLARAR VARIABLE CONSTRUCTORES / DISPOSE

        #region CRUD METHODS
        public ResponseSubCategoria Create(RequestSubCategoria entity)
        {
            SubCategoria subCategoriaEntity = _mapper.Map<SubCategoria>(entity);
            SubCategoria createdSubCategoria = _subCategoriaRepository.Create(subCategoriaEntity);
            return _mapper.Map<ResponseSubCategoria>(createdSubCategoria);
        }

        public List<ResponseSubCategoria> CreateMultiple(List<RequestSubCategoria> list)
        {
            List<SubCategoria> subCategoriaEntities = _mapper.Map<List<SubCategoria>>(list);
            List<SubCategoria> createdSubCategorias = _subCategoriaRepository.CreateMultiple(subCategoriaEntities);
            return _mapper.Map<List<ResponseSubCategoria>>(createdSubCategorias);
        }

        public int Delete(object id)
        {
            return _subCategoriaRepository.Delete(id);
        }

        public int DeleteMultiple(List<RequestSubCategoria> list)
        {
            List<SubCategoria> subCategoriaEntities = _mapper.Map<List<SubCategoria>>(list);
            return _subCategoriaRepository.DeleteMultiple(subCategoriaEntities);
        }

        public List<ResponseSubCategoria> GetAll()
        {
            List<SubCategoria> subCategorias = _subCategoriaRepository.GetAll();
            return _mapper.Map<List<ResponseSubCategoria>>(subCategorias);
        }

        public ResponseFilterGeneric<ResponseSubCategoria> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }

        public ResponseSubCategoria GetById(object id)
        {
            SubCategoria subCategoriaEntity = _subCategoriaRepository.GetById(id);
            return _mapper.Map<ResponseSubCategoria>(subCategoriaEntity);
        }

        public ResponseSubCategoria Update(RequestSubCategoria entity)
        {
            SubCategoria subCategoriaEntity = _mapper.Map<SubCategoria>(entity);
            SubCategoria updatedSubCategoria = _subCategoriaRepository.Update(subCategoriaEntity);
            return _mapper.Map<ResponseSubCategoria>(updatedSubCategoria);
        }

        public List<ResponseSubCategoria> UpdateMultiple(List<RequestSubCategoria> list)
        {
            List<SubCategoria> subCategoriaEntities = _mapper.Map<List<SubCategoria>>(list);
            List<SubCategoria> updatedSubCategorias = _subCategoriaRepository.UpdateMultiple(subCategoriaEntities);
            return _mapper.Map<List<ResponseSubCategoria>>(updatedSubCategorias);
        }
        #endregion CRUD METHODS
    }

}
