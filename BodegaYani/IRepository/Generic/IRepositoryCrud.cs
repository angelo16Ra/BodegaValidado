using System;
using RequestResponseModels.Generic;

namespace IRepository.Generic
{
    /// <summary>
    /// Dispone de todos los metodos del CRUD
    /// </summary>
    /// <typeparam name="T"></typeparam> 
    public interface IRepositoryCrud<T>:IDisposable
    {
        /// <summary>
        /// Retorna todos los lista de la tabla <typeparamref name="T"/>
        /// </summary>
        /// <returns> LISTA DE <typeparamref name="T"/> </returns>  
        List<T> GetAll();

        /// <summary>
        /// Retorna un registro de la tabla filtrado por el primary key <typeparamref name="T"/>
        /// </summary>
        /// <param name="id"> Primary Key</param>
        /// <returns> <typeparamref name="T"/> </returns>
        T GetById(object id);

        /// <summary>
        /// Inserta un registro a la tabla <typeparamref name="T"/>
        /// </summary>
        /// <param name="entity"> <typeparamref name="T"/> </param>
        /// <returns> <typeparamref name="T"/> </returns>
        T Create(T entity);

        /// <summary>
        /// Inserta varios registros en la tabla <typeparamref name="T"/>
        /// </summary>
        /// <param name="lista"> List<paramref name="lista"/> </param>
        /// <returns> List<paramref name="lista"/> </returns>
        List<T> CreateMultiple(List<T> lista);

        /// <summary>
        /// Actualiza un registro a la tabla <typeparamref name="T"/>
        /// </summary>
        /// <param name="entity"> <typeparamref name="T"/> </param>
        /// <returns> <typeparamref name="T"/> </returns>
        T Update(T entity);

        /// <summary>
        /// Actializa varios registros en la tabla <typeparamref name="T"/>
        /// </summary>
        /// <param name="lista"> List<paramref name="lista"/> </param>
        /// <returns> List<paramref name="lista"/> </returns>
        List<T> UpdateMultiple(List<T> lista);

        /// <summary>
        /// Elimina un registro de la tabla filtrado por el primary key <typeparamref name="T"/>
        /// </summary>
        /// <param name="id"> Primary Key</param>
        /// <returns> int </returns>
        int Delete(object id);

        /// <summary>
        /// Elimina varios registros de la tabla filtrado por el primary key <typeparamref name="T"/>
        /// </summary>
        /// <param name="lista"> List<paramref name="lista"/> </param>
        /// <returns> int cantidad de registros eliminados </returns>
        int DeleteMultiple(List<T> lista);
        ResponseFilterGeneric<T> GetByFilter(RequestFilterGeneric request);
    }
}
