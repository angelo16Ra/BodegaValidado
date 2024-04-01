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
    public class RepositoryCategoria : RepositoryCrud<Categoria>, IRepositoryCategoria
    {
        public ResponseFilterGeneric<Categoria> GetByFilter(RequestFilterGeneric request)
        {
            var query = dbSet.Where(x => x.CodigoCategoria == x.CodigoCategoria);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoCategoria == int.Parse(j.Value));
                            break;
                        case "nombre":
                            query = query.Where(x => x.Nombre.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "descripcion":
                            query = query.Where(x => x.Descripcion.ToLower().Contains(j.Value.ToLower()));
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
                                query = query.Where(x => x.FechaActualizacion == fechaActualizacion);
                            }
                            break;
                    }
                }
            });

            ResponseFilterGeneric<Categoria> res = new ResponseFilterGeneric<Categoria>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.Nombre)
                .ToList();

            return res;

        }
    }
}
