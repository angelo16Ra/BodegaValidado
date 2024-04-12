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
    public class RepositorySubCategoria : RepositoryCrud<SubCategoria>, IRepositorySubCategoria
    {
        public ResponseFilterGeneric<SubCategoria> GetByFilter(RequestFilterGeneric request)
        {
            var query = dbSet.Where(x => x.CodigoSubCategoria == x.CodigoSubCategoria);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoSubCategoria == int.Parse(j.Value));
                            break;
                        case "codigoCategoria":
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
                            query = query.Where(x => x.FechaRegistro == DateTime.Parse(j.Value));
                            break;
                        case "fechaActualizacion":
                            query = query.Where(x => x.FechaActualizacion == DateTime.Parse(j.Value));
                            break;
                    }
                }
            });

            ResponseFilterGeneric<SubCategoria> res = new ResponseFilterGeneric<SubCategoria>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.CodigoSubCategoria)
                .ToList();

            return res;

        }
        public ResponseFilterGeneric<VsubCategoria> GetByFilterView(RequestFilterGeneric request)
        {
            var query = db.VsubCategorias.Where(x => x.CodigoSubCategoria == x.CodigoSubCategoria);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoSubCategoria == int.Parse(j.Value));
                            break;
                        case "codigoCategoria":
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
                            query = query.Where(x => x.FechaRegistro == DateTime.Parse(j.Value));
                            break;
                        case "fechaActualizacion":
                            query = query.Where(x => x.FechaActualizacion == DateTime.Parse(j.Value));
                            break;
                        case "nombreCategoria":
                            query = query.Where(x => x.NombreCategoria.ToLower().Contains(j.Value.ToLower()));
                            break;
                    }
                }
            });

            ResponseFilterGeneric<VsubCategoria> res = new ResponseFilterGeneric<VsubCategoria>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.CodigoSubCategoria)
                .ToList();

            return res;
        }
    }
}
