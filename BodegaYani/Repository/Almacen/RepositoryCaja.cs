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
    public class RepositoryCaja : RepositoryCrud<Caja>, IRepositoryCaja
    {
        public ResponseFilterGeneric<Caja> GetByFilter(RequestFilterGeneric request)
        {
            var query = dbSet.Where(x => x.CodigoCaja == x.CodigoCaja);
            request.Filtros.ForEach(j =>
            {
                if (!string.IsNullOrEmpty(j.Value))
                {
                    switch (j.Name)
                    {
                        case "codigo":
                            query = query.Where(x => x.CodigoCaja == int.Parse(j.Value));
                            break;
                        case "fecha":
                            if (DateTime.TryParse(j.Value, out DateTime fecha))
                            {
                                query = query.Where(x => x.Fecha == fecha);
                            }
                            break;
                        case "usuarioApertura":
                            query = query.Where(x => x.UsuarioApertura.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "usuarioCierre":
                            query = query.Where(x => x.UsuarioCierre.ToLower().Contains(j.Value.ToLower()));
                            break;
                        case "estado":
                            query = query.Where(x => x.Estado == bool.Parse(j.Value));
                            break;
                        case "montoApertura":
                            query = query.Where(x => x.MontoApertura == decimal.Parse(j.Value));
                            break;
                        case "montoCierre":
                            query = query.Where(x => x.MontoCierre == decimal.Parse(j.Value));
                            break;
                        case "montoAdicional":
                            query = query.Where(x => x.MontoAdicional == decimal.Parse(j.Value));
                            break;
                    }
                }
            });

            ResponseFilterGeneric<Caja> res = new ResponseFilterGeneric<Caja>();

            res.TotalRegistros = query.Count();
            res.Lista = query
                .Skip((request.NumeroPagina - 1) * request.Cantidad).Take(request.Cantidad)
                .OrderBy(x => x.Fecha)
                .ToList();

            return res;

        }
    }
}
