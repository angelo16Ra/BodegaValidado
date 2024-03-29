using AutoMapper;
using DBBodegaYani.BodegaYani;
using IBusiness.Almacen;
using IRepository.Almacen;
using Repository.Almacen;
using RequestResponseModels.Generic;
using RequestResponseModels.Request.Almacen;
using RequestResponseModels.Response.Almacen;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Almacen
{
    public class BusinessUsuario : IBusinessUsuario
    {
        #region DECLARAR VARIABLE CONSTRUCTORES / DISPOSE
        private readonly IRepositoryUsuario _usuario;
        private readonly UtilEncriptarDesencriptar _cripto;
        private readonly IMapper _mapper;

        public BusinessUsuario(IMapper mapper)
        {
            _mapper = mapper;
            _usuario = new RepositoryUsuario();
            _cripto = new UtilEncriptarDesencriptar();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARAR VARIABLE CONSTRUCTORES / DISPOSE

        #region CRUD METHODS
        public ResponseUsuario Create(RequestUsuario entity)
        {
            Usuario usuarios = _mapper.Map<Usuario>(entity);
            usuarios.Password = _cripto.encriptar_AES(usuarios.Password);
            usuarios = _usuario.Create(usuarios);
            ResponseUsuario response = _mapper.Map<ResponseUsuario>(usuarios);
            return response;

        }

        public List<ResponseUsuario> CreateMultiple(List<RequestUsuario> lista)
        {
            List<Usuario> usuarios = _mapper.Map<List<Usuario>>(lista);
            usuarios = _usuario.CreateMultiple(usuarios);
            List<ResponseUsuario> response = _mapper.Map<List<ResponseUsuario>>(usuarios);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _usuario.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestUsuario> lista)
        {
            List<Usuario> usuarios = _mapper.Map<List<Usuario>>(lista);
            int cantidad = _usuario.DeleteMultiple(usuarios);
            return cantidad;
        }

        public List<ResponseUsuario> GetAll()
        {
            List<Usuario> usuarios = _usuario.GetAll();
            List<ResponseUsuario> response = _mapper.Map<List<ResponseUsuario>>(usuarios);
            return response;
        }

        public ResponseFilterGeneric<ResponseUsuario> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }

        public ResponseUsuario GetById(object id)
        {
            Usuario usuarios = _usuario.GetById(id);
            ResponseUsuario response = _mapper.Map<ResponseUsuario>(usuarios);
            return response;
        }

        public ResponseUsuario Update(RequestUsuario entity)
        {
            Usuario usuarios = _mapper.Map<Usuario>(entity);
            usuarios = _usuario.Update(usuarios);
            ResponseUsuario response = _mapper.Map<ResponseUsuario>(usuarios);
            return response;
        }

        public List<ResponseUsuario> UpdateMultiple(List<RequestUsuario> lista)
        {
            List<Usuario> usuarios = _mapper.Map<List<Usuario>>(lista);
            usuarios = _usuario.UpdateMultiple(usuarios);
            List<ResponseUsuario> response = _mapper.Map<List<ResponseUsuario>>(usuarios);
            return response;
        }

        public Vusuario BuscarPorNombreUsuario(string username)
        {
            Vusuario _vusuario = _usuario.GetByVistaUserName(username);
            return _vusuario;
        }

        #endregion CRUD METHODS
    }
}
