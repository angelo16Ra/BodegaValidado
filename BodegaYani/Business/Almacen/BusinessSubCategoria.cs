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
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IRepositorySubCategoria _repositorySubCategoria;
        private readonly IMapper _mapper;

        public BusinessSubCategoria(IMapper mapper)
        {
            _mapper = mapper;
            _repositorySubCategoria = new RepositorySubCategoria();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region CRUD METHODS

        public List<ResponseSubCategoria> GetAll()
        {
            List<SubCategoria> subCategorias = _repositorySubCategoria.GetAll();
            List<ResponseSubCategoria> result = _mapper.Map<List<ResponseSubCategoria>>(subCategorias);
            return result;
        }

        public ResponseSubCategoria GetById(object id)
        {
            SubCategoria subCategoria = _repositorySubCategoria.GetById(id);
            ResponseSubCategoria result = _mapper.Map<ResponseSubCategoria>(subCategoria);
            return result;
        }

        public ResponseSubCategoria Create(RequestSubCategoria entity)
        {
            SubCategoria subCategoria = _mapper.Map<SubCategoria>(entity);
            subCategoria = _repositorySubCategoria.Create(subCategoria);
            ResponseSubCategoria result = _mapper.Map<ResponseSubCategoria>(subCategoria);
            return result;
        }

        public List<ResponseSubCategoria> CreateMultiple(List<RequestSubCategoria> lista)
        {
            List<SubCategoria> subCategorias = _mapper.Map<List<SubCategoria>>(lista);
            subCategorias = _repositorySubCategoria.CreateMultiple(subCategorias);
            List<ResponseSubCategoria> result = _mapper.Map<List<ResponseSubCategoria>>(subCategorias);
            return result;
        }

        public ResponseSubCategoria Update(RequestSubCategoria entity)
        {
            SubCategoria subCategoria = _mapper.Map<SubCategoria>(entity);
            subCategoria = _repositorySubCategoria.Update(subCategoria);
            ResponseSubCategoria result = _mapper.Map<ResponseSubCategoria>(subCategoria);
            return result;
        }

        public List<ResponseSubCategoria> UpdateMultiple(List<RequestSubCategoria> lista)
        {
            List<SubCategoria> subCategorias = _mapper.Map<List<SubCategoria>>(lista);
            subCategorias = _repositorySubCategoria.UpdateMultiple(subCategorias);
            List<ResponseSubCategoria> response = _mapper.Map<List<ResponseSubCategoria>>(subCategorias);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _repositorySubCategoria.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestSubCategoria> lista)
        {
            List<SubCategoria> subCategorias = _mapper.Map<List<SubCategoria>>(lista);
            int cantidad = _repositorySubCategoria.DeleteMultiple(subCategorias);
            return cantidad;
        }

        public ResponseFilterGeneric<ResponseSubCategoria> GetByFilter(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseSubCategoria> result = _mapper.Map<ResponseFilterGeneric<ResponseSubCategoria>>(_repositorySubCategoria.GetByFilter(request));
            return result;
        }

        #endregion CRUD METHODS

    }

}
