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
            x.UserName.ToLower() == UserName.ToLower()).FirstOrDefault();
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
                        case "fechaRegistro":
                            if (DateTime.TryParse(j.Value, out DateTime fechaRegistro))
                            {
                                query = query.Where(x => x.FechaRegistro == fechaRegistro);
                            }
                            break;
                        case "fechaActualizacion":
                            if (DateTime.TryParse(j.Value, out DateTime fechaActualizacion))
                            {
                                query = query.Where(x => x.FechaActualizar == fechaActualizacion);
                            }
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

        public ResponseFilterGeneric<Vusuario> GetByFilterView(RequestFilterGeneric request)
        {
            var query = db.Vusuarios.Where(x => x.CodigoUsuario == x.CodigoUsuario);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoUsuario == int.Parse(j.Value));
                            break;
                        case "userName":
                            query = query.Where(x => x.UserName.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "password":
                            query = query.Where(x => x.Password.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "estado":
                            query = query.Where(x => x.Estado == bool.Parse(j.Value));
                            break;
                        case "fechaRegistro":
                            if (DateTime.TryParse(j.Value, out DateTime fechaRegistro))
                            {
                                query = query.Where(x => x.FechaRegistro == fechaRegistro);
                            }
                            break;
                        case "fechaActualizacion":
                            if (DateTime.TryParse(j.Value, out DateTime fechaActualizacion))
                            {
                                query = query.Where(x => x.FechaActualizar == fechaActualizacion);
                            }
                            break;
                        case "codigoPersona":
                            query = query.Where(x => x.CodigoPersona == int.Parse(j.Value));
                            break;
                        case "numeroDocumento":
                            query = query.Where(x => x.NumeroDocumento.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "nombrePersona":
                            query = query.Where(x => x.NombrePersona.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "apPaterno":
                            query = query.Where(x => x.ApellidoPaterno.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "apMaterno":
                            query = query.Where(x => x.ApellidoMaterno.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "sexo":
                            query = query.Where(x => x.Genero.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "fechaNacimiento":
                            if (DateTime.TryParse(j.Value, out DateTime FechaNacimiento))
                            {
                                query = query.Where(x => x.FechaNacimiento == FechaNacimiento);
                            }
                            break;
                        case "correo":
                            query = query.Where(x => x.Correo.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "celular":
                            query = query.Where(x => x.Celular.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "codigoRol":
                            query = query.Where(x => x.CodigoRol == int.Parse(j.Value));
                            break;
                        case "nombreRol":
                            query = query.Where(x => x.NombreRol.ToLower().Contains(j.Value.ToLower()));
                            break;
                    }
                }
            });

            ResponseFilterGeneric<Vusuario> res = new ResponseFilterGeneric<Vusuario>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.UserName)
                .ToList();

            return res;
        }
    }
}

