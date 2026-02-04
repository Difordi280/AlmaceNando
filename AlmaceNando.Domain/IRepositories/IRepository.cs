using System;
using System.Collections.Generic;
using System.Text;
using AlmaceNando.Domain.Models.Base;

namespace AlmaceNando.Domain.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        // Descargar toda la base de datos en una lista
        Task< IEnumerable<T>> GetAllAny();
        // Para cargar un elemento a la base de datos
        Task AddAnsy(T entity);
        // eliminacion de un elemento de la base de datos
        Task DeleteAnsy(Guid id);
        // Actualizacion de un elemento de la base de datos
        Task UpdateAnsy(Guid id , T entity);
    }
}
