using DBBodegaYani.BodegaYani;
using IRepository.Almacen;
using Repository.Generic;
using RequestResponseModels.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repository.Almacen.RepositoryAlmacene;

namespace Repository.Almacen

{
    public class RepositoryAlmacene : RepositoryCrud<Almacene>, IRepositoryAlmacene
    {
        public ResponseFilterGeneric<Almacene> GetByFilter(RequestFilterGeneric request)
        {
            var query = dbSet.Where(x => x.CodigoAlmacenes == x.CodigoAlmacenes);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoAlmacenes == int.Parse(j.Value));
                            break;
                        case "nombre":
                            query = query.Where(x => x.Nombre.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "capacidadLimite":
                            query = query.Where(x => x.CapacidadLimite == int.Parse(j.Value));
                            break;
                        case "estado":
                            query = query.Where(x => x.Estado == bool.Parse(j.Value));
                            break;
                    }
                }
            });

            ResponseFilterGeneric<Almacene> res = new ResponseFilterGeneric<Almacene>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.Nombre)
                .ToList();

            return res;

        }
    }
}
