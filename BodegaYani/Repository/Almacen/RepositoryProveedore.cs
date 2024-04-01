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
    public class RepositoryProveedore : RepositoryCrud<Proveedore>, IRepositoryProveedore
    {
        public ResponseFilterGeneric<Proveedore> GetByFilter(RequestFilterGeneric request)
        {
            var query = dbSet.Where(x => x.CodigoProveedor == x.CodigoProveedor);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoProveedor == int.Parse(j.Value));
                            break;
                        case "ruc":
                            query = query.Where(x => x.Ruc.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "razonSocial":
                            query = query.Where(x => x.RazonSocial.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "telefono":
                            query = query.Where(x => x.Telefono.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "correo":
                            query = query.Where(x => x.Correo.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "fechaRegistro":
                            query = query.Where(x => x.FechaRegistro == DateTime.Parse(j.Value));
                            break;
                        case "fechaActualizacion":
                            query = query.Where(x => x.FechaActualizacion == DateTime.Parse(j.Value));
                            break;
                        case "estado":
                            query = query.Where(x => x.Estado == bool.Parse(j.Value));
                            break;
                    }
                }
            });

            ResponseFilterGeneric<Proveedore> res = new ResponseFilterGeneric<Proveedore>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.CodigoProveedor)
                .ToList();

            return res;

        }
    }
}
