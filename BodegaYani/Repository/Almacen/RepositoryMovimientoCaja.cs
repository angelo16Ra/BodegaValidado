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
    public class RepositoryMovimientoCaja : RepositoryCrud<MovimientoCaja>, IRepositoryMovimientoCaja
    {
        public ResponseFilterGeneric<MovimientoCaja> GetByFilter(RequestFilterGeneric request)
        {
            var query = dbSet.Where(x => x.CodigoMovimientoCaja == x.CodigoMovimientoCaja);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoMovimientoCaja == int.Parse(j.Value));
                            break;
                        case "tipo":
                            query = query.Where(x => x.Tipo.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "monto":
                            query = query.Where(x => x.Monto == decimal.Parse(j.Value));
                            break;
                        case "codigoCaja":
                            query = query.Where(x => x.CodigoCaja == int.Parse(j.Value));
                            break;
                        case "codigoPedido":
                            query = query.Where(x => x.CodigoPedido == int.Parse(j.Value));
                            break;
                    }
                }
            });

            ResponseFilterGeneric<MovimientoCaja> res = new ResponseFilterGeneric<MovimientoCaja>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.CodigoMovimientoCaja)
                .ToList();

            return res;

        }
    }

}
