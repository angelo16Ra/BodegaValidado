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
    public class RepositoryRol : RepositoryCrud<Rol>, IRepositoryRol
    {
        public ResponseFilterGeneric<Rol> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }
    }

}
