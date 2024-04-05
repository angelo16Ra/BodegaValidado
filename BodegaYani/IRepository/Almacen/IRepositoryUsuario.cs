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
    public interface IRepositoryUsuario : IRepositoryCrud<Usuario>
    {
        Usuario BuscarPorNombreUsuario(string UserName);
        Vusuario GetByVistaUserName(string UserName);

        ResponseFilterGeneric<Vusuario> GetByFilterView(RequestFilterGeneric request);

    }
}
