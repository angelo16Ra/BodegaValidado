using DBBodegaYani.BodegaYani;
using IRepository.Generic;
using RequestResponseModels.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Almacen
{
    public interface IRepositoryMovimientoCaja : IRepositoryCrud<MovimientoCaja>
    {
        ResponseFilterGeneric<VmovimientoCaja> GetByFilterView(RequestFilterGeneric request);
    }

}
