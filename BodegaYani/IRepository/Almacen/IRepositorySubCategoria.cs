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
    public interface IRepositorySubCategoria : IRepositoryCrud<SubCategoria>
    {
        ResponseFilterGeneric<VsubCategoria> GetByFilterView(RequestFilterGeneric request);
    }
}
