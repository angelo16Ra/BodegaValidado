using AutoMapper;
using RequestResponseModels.Generic;
using IRepository.Almacen;
using Repository.Almacen;
using RequestResponseModels.Request.Almacen;
using RequestResponseModels.Response.Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBBodegaYani.BodegaYani;
using IBusiness.Almacen;
using DocumentFormat.OpenXml.Vml.Office;

namespace Business.Almacen
{
    public class BusinessCategoria : IBusinessCategoria
    {
        #region DECLARAR VARIABLE CONSTRUCTORES / DISPOSE
        private readonly IRepositoryCategorias _categoriaRepository;
        private readonly IMapper _mapper;

        public BusinessCategoria(IMapper mapper)
        {
            _mapper = mapper;
            _categoriaRepository = new RepositoryCategoria();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion DECLARAR VARIABLE CONSTRUCTORES / DISPOSE

        #region CRUD METHODS
        public ResponseCategoria Create(RequestCategoria entity)
        {
            Categoria categoriaEntity = _mapper.Map<Categoria>(entity);
            Categoria createdCategoria = _categoriaRepository.Create(categoriaEntity);
            return _mapper.Map<ResponseCategoria>(createdCategoria);
        }

        public List<ResponseCategoria> CreateMultiple(List<RequestCategoria> list)
        {
            List<Categoria> categoriaEntities = _mapper.Map<List<Categoria>>(list);
            List<Categoria> createdCategorias = _categoriaRepository.CreateMultiple(categoriaEntities);
            return _mapper.Map<List<ResponseCategoria>>(createdCategorias);
        }

        public int Delete(object id)
        {
            return _categoriaRepository.Delete(id);
        }

        public int DeleteMultiple(List<RequestCategoria> list)
        {
            List<Categoria> categoriaEntities = _mapper.Map<List<Categoria>>(list);
            return _categoriaRepository.DeleteMultiple(categoriaEntities);
        }

        public List<ResponseCategoria> GetAll()
        {
            List<Categoria> categorias = _categoriaRepository.GetAll();
            return _mapper.Map<List<ResponseCategoria>>(categorias);
        }

        public ResponseFilterGeneric<ResponseCategoria> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }

        public ResponseCategoria GetById(object id)
        {
            Categoria categoriaEntity = _categoriaRepository.GetById(id);
            return _mapper.Map<ResponseCategoria>(categoriaEntity);
        }

        public ResponseCategoria Update(RequestCategoria entity)
        {
            Categoria categoriaEntity = _mapper.Map<Categoria>(entity);
            Categoria updatedCategoria = _categoriaRepository.Update(categoriaEntity);
            return _mapper.Map<ResponseCategoria>(updatedCategoria);
        }

        public List<ResponseCategoria> UpdateMultiple(List<RequestCategoria> list)
        {
            List<Categoria> categoriaEntities = _mapper.Map<List<Categoria>>(list);
            List<Categoria> updatedCategorias = _categoriaRepository.UpdateMultiple(categoriaEntities);
            return _mapper.Map<List<ResponseCategoria>>(updatedCategorias);
        }
        #endregion CRUD METHODS
    }

}
