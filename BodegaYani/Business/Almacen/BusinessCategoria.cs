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
        private readonly IRepositoryCategoria _categoriaRepository;
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

        public List<ResponseCategoria> GetAll()
        {
            List<Categoria> categorias = _categoriaRepository.GetAll();
            List<ResponseCategoria> result = _mapper.Map<List<ResponseCategoria>>(categorias);
            return result;
        }

        public ResponseCategoria GetById(object id)
        {
            Categoria categoria = _categoriaRepository.GetById(id);
            ResponseCategoria result = _mapper.Map<ResponseCategoria>(categoria);
            return result;
        }

        public ResponseCategoria Create(RequestCategoria entity)
        {
            Categoria categoria = _mapper.Map<Categoria>(entity);
            categoria = _categoriaRepository.Create(categoria);
            ResponseCategoria result = _mapper.Map<ResponseCategoria>(categoria);
            return result;
        }

        public List<ResponseCategoria> CreateMultiple(List<RequestCategoria> lista)
        {
            List<Categoria> categorias = _mapper.Map<List<Categoria>>(lista);
            categorias = _categoriaRepository.CreateMultiple(categorias);
            List<ResponseCategoria> result = _mapper.Map<List<ResponseCategoria>>(categorias);
            return result;
        }

        public ResponseCategoria Update(RequestCategoria entity)
        {
            Categoria categoria = _mapper.Map<Categoria>(entity);
            categoria = _categoriaRepository.Update(categoria);
            ResponseCategoria result = _mapper.Map<ResponseCategoria>(categoria);
            return result;
        }

        public List<ResponseCategoria> UpdateMultiple(List<RequestCategoria> lista)
        {
            List<Categoria> categorias = _mapper.Map<List<Categoria>>(lista);
            categorias = _categoriaRepository.UpdateMultiple(categorias);
            List<ResponseCategoria> response = _mapper.Map<List<ResponseCategoria>>(categorias);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _categoriaRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestCategoria> lista)
        {
            List<Categoria> categorias = _mapper.Map<List<Categoria>>(lista);
            int cantidad = _categoriaRepository.DeleteMultiple(categorias);
            return cantidad;
        }

        public ResponseFilterGeneric<ResponseCategoria> GetByFilter(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseCategoria> result = _mapper.Map<ResponseFilterGeneric<ResponseCategoria>>(_categoriaRepository.GetByFilter(request));
            return result;
        }

        #endregion CRUD METHODS

    }

}
