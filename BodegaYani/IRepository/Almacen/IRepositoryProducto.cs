using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBBodegaYani;
using DBBodegaYani.BodegaYani;
using IRepository.Generic;
using RequestResponseModels.Generic;

namespace IRepository.Almacen
{
    public interface IRepositoryProducto: IRepositoryCrud<Producto>
    {
        ResponseFilterGeneric<Vproducto> GetByFilterView(RequestFilterGeneric request);
    }
}
