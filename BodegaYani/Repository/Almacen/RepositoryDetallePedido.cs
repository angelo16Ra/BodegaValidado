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
    public class RepositoryDetallePedido : RepositoryCrud<DetallePedido>, IRepositoryDetallePedido
    {
        public ResponseFilterGeneric<DetallePedido> GetByFilter(RequestFilterGeneric request)
        {
            var query = dbSet.Where(x => x.CodigoDetallePedido == x.CodigoDetallePedido);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoDetallePedido == int.Parse(j.Value));
                            break;
                        case "CodigoPedido":
                            query = query.Where(x => x.CodigoPedido == int.Parse(j.Value));
                            break;
                        case "cantidad":
                            query = query.Where(x => x.Cantidad == decimal.Parse(j.Value));
                            break;
                        case "precioTotal":
                            query = query.Where(x => x.PrecioTotal == decimal.Parse(j.Value));
                            break;
                        case "precioUnitario":
                            query = query.Where(x => x.PrecioUnitario == decimal.Parse(j.Value));
                            break;
                        case "estado":
                            query = query.Where(x => x.Estado == bool.Parse(j.Value));
                            break;
                    }
                }
            });

            ResponseFilterGeneric<DetallePedido> res = new ResponseFilterGeneric<DetallePedido>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.CodigoDetallePedido)
                .ToList();

            return res;

        }
    }

}
