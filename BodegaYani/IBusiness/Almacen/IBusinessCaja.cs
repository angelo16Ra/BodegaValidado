﻿using DBBodegaYani.BodegaYani;
using IBusiness.Generic;
using RequestResponseModels.Generic;
using RequestResponseModels.Request.Almacen;
using RequestResponseModels.Response.Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Almacen
{
    public interface IBusinessCaja : IBusinessCrud<RequestCaja, ResponseCaja>
    {
        ResponseFilterGeneric<Vcaja> GetByFilterView(RequestFilterGeneric request);
    }
}
