using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Infrastructure.Interfaces;
using Infrastructure.Storage;
using MongoDB.Driver;

namespace Infrastructure
{
    public abstract class MongoEntityRepository<T> : IEntityRepository<T> where T : Entity
    {
        private readonly MongoExpertClient _mongoClient;
        protected readonly IMongoCollection<T> Collection;
        protected FilterDefinition<T> DefaultReadFilter;

        protected List<T> Inserts { get; set; }

        protected MongoEntityRepository(MongoExpertClient client)
        {
            _mongoClient = client;
            Collection = client.Set<T>();
            Inserts = new List<T>();
            DefaultReadFilter = Builders<T>.Filter.Empty;
        }

        public abstract T GetById(Guid id);

        public IList<T> Get()
        {
            var queryFilter = (DefaultReadFilter);
            var items = Collection.Find(queryFilter)
                .ToList();
            return items;
        }

        public virtual void Add(T entity)
        {
            Inserts.Add(entity);
        }

        public abstract void Update(T entity);

        public abstract void Delete(T entity);

        public virtual void SaveChanges()
        {
            if (Inserts.Any())
                Collection.InsertMany(Inserts);
            Inserts.Clear();
        }
    }
}