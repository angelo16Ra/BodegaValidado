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
    public class RepositoryPersona : RepositoryCrud<Persona>, IRepositoryPersona
    {
        public List<Persona> GetAutoComplete(string query)
        {
            throw new NotImplementedException();
        }
        public ResponseFilterGeneric<Persona> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }
    }


}
