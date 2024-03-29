﻿using DBBodegaYani.BodegaYani;
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
    public class RepositoryUnidadMedida : RepositoryCrud<UnidadMedida>, IRepositoryUnidadMedida
    {
        public ResponseFilterGeneric<UnidadMedida> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }
    }

}
