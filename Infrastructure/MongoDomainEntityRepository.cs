using System;
using System.Collections.Generic;
using Domain;
using Infrastructure.Storage;

namespace Infrastructure
{
    public class MongoDomainEntityRepository<T> : MongoEntityRepository<T> where T : Entity
    {
        protected List<T> Deletes { get; set; }
        protected List<T> Updates { get; set; }

        public MongoDomainEntityRepository(MongoExpertClient client) : base(client)
        {
        }

        public override T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}