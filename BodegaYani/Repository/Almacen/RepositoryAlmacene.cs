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
            throw new NotImplementedException();
        }
    }
}
