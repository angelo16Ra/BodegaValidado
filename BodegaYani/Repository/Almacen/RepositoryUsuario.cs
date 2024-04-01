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
            var query = dbSet.Where(x => x.CodigoUsuario == x.CodigoUsuario);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoUsuario == int.Parse(j.Value));
                            break;
                        case "username":
                            query = query.Where(x => x.UserName.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "password":
                            query = query.Where(x => x.Password.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "estado":
                            query = query.Where(x => x.Estado == bool.Parse(j.Value));
                            break;
                    }
                }
            });

            ResponseFilterGeneric<Usuario> res = new ResponseFilterGeneric<Usuario>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.UserName)
                .ToList();

            return res;

        }
    }
}

