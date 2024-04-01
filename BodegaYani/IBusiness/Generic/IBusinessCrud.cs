using RequestResponseModels.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Generic
{
    /// <summary>
    /// Declara los metodos del CRUD
    /// </summary>
    /// <typeparam name="T"> REQUEST </typeparam>
    /// <typeparam name="Y"> RESPONSE </typeparam>
    public interface IBusinessCrud<T,Y>:IDisposable
    {
        List<Y> GetAll();
        Y GetById(object id);
        Y Create(T entity);
        List<Y> CreateMultiple(List<T> lista);
        Y Update(T entity);
        List<Y> UpdateMultiple(List<T> lista);
        int Delete(object id);
        int DeleteMultiple(List<T> lista);
        ResponseFilterGeneric<Y> GetByFilter(RequestFilterGeneric request);
    }
}
