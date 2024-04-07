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
    public class RepositoryProducto : RepositoryCrud<Producto>, IRepositoryProducto
    {
        public ResponseFilterGeneric<Producto> GetByFilter(RequestFilterGeneric request)
        {
            var query = dbSet.Where(x => x.CodigoProducto == x.CodigoProducto);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoProducto == int.Parse(j.Value));
                            break;
                        case "codigoUnidadMedida":
                            query = query.Where(x => x.CodigoUnidadMedida == int.Parse(j.Value));
                            break;
                        case "codigoCategoria":
                            query = query.Where(x => x.CodigoCategoria == int.Parse(j.Value));
                            break;
                        case "codigoSubCategoria":
                            query = query.Where(x => x.CodigoSubCategoria == int.Parse(j.Value));
                            break;
                        case "codigoProveedor":
                            query = query.Where(x => x.CodigoProveedor == int.Parse(j.Value));
                            break;
                        case "codigoAlmacenes":
                            query = query.Where(x => x.CodigoAlmacenes == int.Parse(j.Value));
                            break;
                        case "nombre":
                            query = query.Where(x => x.Nombre.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "stock":
                            query = query.Where(x => x.Stock.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "precio":
                            query = query.Where(x => x.Precio == decimal.Parse(j.Value));
                            break;
                        case "imagen":
                            query = query.Where(x => x.Imagen.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "descripcion":
                            query = query.Where(x => x.Descripcion.ToLower().Contains(j.Value.ToLower()));
                            break;
                    }
                }
            });

            ResponseFilterGeneric<Producto> res = new ResponseFilterGeneric<Producto>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.CodigoProducto)
                .ToList();

            return res;

        }

        public ResponseFilterGeneric<Vproducto> GetByFilterView(RequestFilterGeneric request)
        {
            var query = db.Vproductos.Where(x => x.CodigoProducto == x.CodigoProducto);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoProducto == int.Parse(j.Value));
                            break;
                        case "codigoUnidadMedida":
                            query = query.Where(x => x.CodigoUnidadMedida == int.Parse(j.Value));
                            break;
                        case "codigoCategoria":
                            query = query.Where(x => x.CodigoCategoria == int.Parse(j.Value));
                            break;
                        case "codigoSubCategoria":
                            query = query.Where(x => x.CodigoSubCategoria == int.Parse(j.Value));
                            break;
                        case "codigoProveedor":
                            query = query.Where(x => x.CodigoProveedor == int.Parse(j.Value));
                            break;
                        case "codigoAlmacenes":
                            query = query.Where(x => x.CodigoAlmacenes == int.Parse(j.Value));
                            break;
                        case "nombre":
                            query = query.Where(x => x.Nombre.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "stock":
                            query = query.Where(x => x.Stock.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "precio":
                            query = query.Where(x => x.Precio == decimal.Parse(j.Value));
                            break;
                        case "imagen":
                            query = query.Where(x => x.Imagen.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "descripcion":
                            query = query.Where(x => x.Descripcion.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "NomnombreMedida":
                            query = query.Where(x => x.NomnombreMedida.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "NombreCategoria":
                            query = query.Where(x => x.NombreCategoria.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "NombreSub":
                            query = query.Where(x => x.NombreSub.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "NombreProveedor":
                            query = query.Where(x => x.NombreProveedor.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "NombreAlmacen":
                            query = query.Where(x => x.NombreAlmacen.ToLower().Contains(j.Value.ToLower()));
                            break;
                    }
                }
            });

            ResponseFilterGeneric<Vproducto> res = new ResponseFilterGeneric<Vproducto>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.CodigoProducto)
                .ToList();

            return res;

        }
    }
}
