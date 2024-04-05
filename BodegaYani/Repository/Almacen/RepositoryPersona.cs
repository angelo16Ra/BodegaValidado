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
    public class RepositoryPersona : RepositoryCrud<Persona>, IRepositoryPersona
    {
        //public List<Persona> GetAutoComplete(string query)
        //{
        //    throw new NotImplementedException();
        //}
        public ResponseFilterGeneric<Persona> GetByFilter(RequestFilterGeneric request)
        {
            var query = dbSet.Where(x => x.CodigoPersona == x.CodigoPersona);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoPersona == int.Parse(j.Value));
                            break;
                        case "codigoDocumento":
                            query = query.Where(x => x.CodigoDocumento == int.Parse(j.Value));
                            break;
                        case "codigoRol":
                            query = query.Where(x => x.CodigoRol == int.Parse(j.Value));
                            break;
                        case "numeroDocumento":
                            query = query.Where(x => x.NumeroDocumento.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "nombre":
                            query = query.Where(x => x.Nombre.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "apPaterno":
                            query = query.Where(x => x.ApPaterno.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "apMaterno":
                            query = query.Where(x => x.ApMaterno.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "sexo":
                            query = query.Where(x => x.Sexo.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "fechaNacimiento":
                            query = query.Where(x => x.FechaNacimiento == DateTime.Parse(j.Value));
                            break;
                        case "correo":
                            query = query.Where(x => x.Correo.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "celular":
                            query = query.Where(x => x.Celular.ToLower().Contains(j.Value.ToLower()));
                            break;
                    }
                }
            });

            ResponseFilterGeneric<Persona> res = new ResponseFilterGeneric<Persona>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.CodigoPersona)
                .ToList();

            return res;

        }
    }


}
