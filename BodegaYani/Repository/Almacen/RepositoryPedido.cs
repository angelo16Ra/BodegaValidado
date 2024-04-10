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
    public class RepositoryPedido : RepositoryCrud<Pedido>, IRepositoryPedido
    {
        public ResponseFilterGeneric<Pedido> GetByFilter(RequestFilterGeneric request)
        {
            var query = dbSet.Where(x => x.CodigoPedido == x.CodigoPedido);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoPedido == int.Parse(j.Value));
                            break;
                        case "codigoUsuario":
                            query = query.Where(x => x.CodigoUsuario == int.Parse(j.Value));
                            break;
                        case "codigoProducto":
                            query = query.Where(x => x.CodigoProducto == int.Parse(j.Value));
                            break;
                        case "MontoTotalPedido":
                            query = query.Where(x => x.MontoTotalPedido == decimal.Parse(j.Value));
                            break;
                        case "montoPagado":
                            query = query.Where(x => x.MontoPagado == decimal.Parse(j.Value));
                            break;
                        case "vuelto":
                            query = query.Where(x => x.Vuelto == decimal.Parse(j.Value));
                            break;
                        case "registroPedido":
                            query = query.Where(x => x.RegistroPedido == DateTime.Parse(j.Value));
                            break;
                        case "entregaPedido":
                            query = query.Where(x => x.EntregaPedido == DateTime.Parse(j.Value));
                            break;
                        case "estado":
                            query = query.Where(x => x.Estado == bool.Parse(j.Value));
                            break;
                    }
                }
            });

            ResponseFilterGeneric<Pedido> res = new ResponseFilterGeneric<Pedido>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.CodigoPedido)
                .ToList();

            return res;

        }

        public ResponseFilterGeneric<Vpedido> GetByFilterView(RequestFilterGeneric request)
        {
            var query = db.Vpedidos.Where(x => x.CodigoPedido == x.CodigoPedido);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoPedido == int.Parse(j.Value));
                            break;
                        case "codigoUsuario":
                            query = query.Where(x => x.CodigoUsuario == int.Parse(j.Value));
                            break;
                        case "codigoProducto":
                            query = query.Where(x => x.CodigoProducto == int.Parse(j.Value));
                            break;
                        case "MontoTotalPedido":
                            query = query.Where(x => x.MontoTotalPedido == decimal.Parse(j.Value));
                            break;
                        case "montoPagado":
                            query = query.Where(x => x.MontoPagado == decimal.Parse(j.Value));
                            break;
                        case "vuelto":
                            query = query.Where(x => x.Vuelto == decimal.Parse(j.Value));
                            break;
                        case "registroPedido":
                            query = query.Where(x => x.RegistroPedido == DateTime.Parse(j.Value));
                            break;
                        case "entregaPedido":
                            query = query.Where(x => x.EntregaPedido == DateTime.Parse(j.Value));
                            break;
                        case "NombreUsuario":
                            query = query.Where(x => x.NombreUsuario.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "NombreProducto":
                            query = query.Where(x => x.NombreProducto.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "Cantidad":
                            query = query.Where(x => x.Cantidad == decimal.Parse(j.Value));
                            break;
                        case "PrecioTotal":
                            query = query.Where(x => x.PrecioTotal == decimal.Parse(j.Value));
                            break;
                        case "PrecioUnitario":
                            query = query.Where(x => x.PrecioUnitario == decimal.Parse(j.Value));
                            break;

                    }
                }
            });

            ResponseFilterGeneric<Vpedido> res = new ResponseFilterGeneric<Vpedido>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.CodigoPedido)
                .ToList();

            return res;
        }
    }

}
