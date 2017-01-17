using System;
using System.Collections.Generic;
using Domain;
using Infrastructure.Interfaces;
using Infrastructure.Storage;

namespace Infrastructure
{
    public abstract class MongoEntityRepository<T> : IEntityRepository<T> where T : Entity
    {
        protected List<T> Inserts { get; set; }

        protected MongoEntityRepository(MongoExpertClient client)
        {

        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public abstract T GetById(Guid id);

        public IList<T> Get()
        {
            throw new NotImplementedException();
        }

        public abstract void Update(T entity);

        public abstract void Delete(T entity);

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}