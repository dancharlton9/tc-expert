using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Infrastructure.Exceptions;
using Infrastructure.Storage;
using MongoDB.Driver;

namespace Infrastructure
{
    public abstract class MongoDomainEntityRepository<T> : MongoEntityRepository<T> where T : Entity
    {
        protected List<Guid> Deletes { get; set; }
        protected List<T> Updates { get; set; }
        protected FilterDefinition<T> DefaultWriteFilter;

        protected MongoDomainEntityRepository(MongoExpertClient client) : base(client)
        {
            Deletes = new List<Guid>();
            Updates = new List<T>();

            DefaultWriteFilter = Builders<T>.Filter.Empty;
        }

        public override T GetById(Guid id)
        {
            var filter = (DefaultReadFilter)
                         & Builders<T>.Filter.Eq(x => x.Id, id);
            var query = Collection.Find(filter)
                .FirstOrDefault();

            if (query == default(T))
                throw new EntityNotFoundException();
            return query;
        }

        public override void Update(T entity)
        {
            Updates.Add(entity);
        }

        public override void Delete(T entity)
        {
            Deletes.Add(entity.Id);
        }

        public override void SaveChanges()
        {
            base.SaveChanges();

            var deleteFilter = DefaultWriteFilter &
                               Builders<T>.Filter.Where(x => Deletes.ToArray().Contains(x.Id));
            Collection.DeleteMany(deleteFilter);
            Deletes.Clear();

            Updates.ForEach(ReplaceEntity);
            Updates.Clear();
        }

        private void ReplaceEntity(T ent)
        {
            var updateFilter = DefaultWriteFilter &
                               Builders<T>.Filter.Eq(x => x.Id, ent.Id);
            Collection.ReplaceOne(updateFilter, ent);
        }
    }
}