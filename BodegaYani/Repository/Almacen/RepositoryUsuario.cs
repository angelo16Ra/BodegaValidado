using DBBodegaYani.BodegaYani;
using IRepository.Almacen;
using Repository.Generic;
using RequestResponseModels.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Almacen
{
    public class RepositoryUsuario : RepositoryCrud<Usuario>, IRepositoryUsuario
    {
        public List<Usuario> GetAutoComplete(string query)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorNombreUsuario(string UserName)
        {
            Usuario Usuario = dbSet
                .Where(x => x.UserName.ToLower() == UserName.ToLower()).FirstOrDefault();
            /*  .Include(x => x.CodigoPersonaNavigation)
              .Include(x => x.CodigoColaboradoresNavigation)*/
            return Usuario;
        }

        public Vusuario GetByVistaUserName(string UserName)
        {
            Vusuario _vusuario = db.Vusuarios.Where(x =>
            x.Username.ToLower() == UserName.ToLower()).FirstOrDefault();
            return _vusuario;
        }

        public ResponseFilterGeneric<Usuario> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }
    }
}

