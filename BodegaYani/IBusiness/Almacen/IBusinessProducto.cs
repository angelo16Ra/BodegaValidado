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
    public interface IBusinessProducto : IBusinessCrud<RequestProducto,ResponseProducto>
    {
        ResponseFilterGeneric<Vproducto> GetByFilterView(RequestFilterGeneric request);
    }
}
