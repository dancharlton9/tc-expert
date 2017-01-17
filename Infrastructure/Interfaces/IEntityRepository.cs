using System;
using System.Collections.Generic;
using Domain;

namespace Infrastructure.Interfaces
{
    public interface IEntityRepository<T> where T : Entity
    {
        void Add(T entity);
        T GetById(Guid id);
        IList<T> Get();
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
