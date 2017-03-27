using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Infrastructure.Exceptions;
using Infrastructure.Storage;
using MongoDB.Driver;
using Xunit;

namespace Infrastructure.Tests
{
    public abstract class MongoDomainEntityRepositoryTests<T> where T : Entity
    {
        private MongoExpertClient _client;
        private MongoDomainEntityRepository<T> _repository;
        protected string ConnectionString;
        protected string DbName;

        protected MongoDomainEntityRepositoryTests()
        {
            ConnectionString = "";
            DbName = "tc-expert-test";
        }

        public void SetupBaseTests(
            MongoExpertClient client,
            MongoDomainEntityRepository<T> repository)
        {
            _client = client;
            _repository = repository;
        }

        public void CleanupBaseTests(
            MongoDomainEntityRepository<T> repository)
        {
            _repository = repository;
        }

        public abstract T GenerateDomainObject(bool includeId = true);

        [Fact]
        public void Add_inserts_new_entity_in_to_the_collection()
        {
            // arrange
            var entity = GenerateDomainObject();

            // act
            _repository.Add(entity);
            _repository.SaveChanges();

            // assert
            var newEntity = _client.Set<T>().Find(x => x.Id == entity.Id).FirstOrDefault();
            Assert.IsType<T>(newEntity);
        }

        [Fact]
        public void Add_creates_a_new_id_if_not_already_initialised()
        {
            // arrange
            var entity = GenerateDomainObject(false);

            // act
            _repository.Add(entity);
            _repository.SaveChanges();

            // assert
            var newEntity = _client.Set<T>().Find(x => x.Id == entity.Id).FirstOrDefault();
            Assert.IsType<T>(newEntity);
        }

        [Fact]
        public void Add_throws_if_entity_identity_is_already_initialised()
        {
            // arrange
            var entity = GenerateDomainObject();
            _repository.Add(entity);
            _repository.SaveChanges();
            var newEnt = GenerateDomainObject(false);
            newEnt.InitialiseIdentity(entity.Id);

            // act
            _repository.Add(newEnt);

            // assert
            Assert.Throws<MongoBulkWriteException<T>>(() => _repository.SaveChanges());
        }

        [Fact]
        public void GetById_returns_previously_added_entity()
        {
            // arrange
            var entity = GenerateDomainObject();
            _repository.Add(entity);
            _repository.SaveChanges();

            // act
            var returnedEntity = _repository.GetById(entity.Id);

            // assert
            Assert.IsType<T>(returnedEntity);
        }

        [Fact]
        public void GetById_throws_if_the_entity_does_not_exist()
        {
            Assert.Throws<EntityNotFoundException>(() => _repository.GetById(Guid.NewGuid()));
        }

        [Fact]
        public void Get_returns_any_added_entities()
        {
            // arrange
            var entities = new List<T>();
            for (var i = 0; i < 5; i++)
            {
                var ent = GenerateDomainObject();
                entities.Add(ent);
                _repository.Add(ent);
            }

            _repository.SaveChanges();

            // act
            var returnedEnts = _repository.Get();

            // assert
            var result = entities.All(x => returnedEnts.Any(e => e.Id == x.Id));
            Assert.True(result);
        }

        [Fact]
        public void Delete_should_remove_the_entity_from_the_collection()
        {
            // arrange
            var entity = AddEntity();

            // act
            _repository.Delete(entity);
            _repository.SaveChanges();

            // assert
            Assert.Throws<EntityNotFoundException>(() => _repository.GetById(entity.Id));
        }

        private T AddEntity()
        {
            var entity = GenerateDomainObject();
            _repository.Add(entity);
            _repository.SaveChanges();
            return entity;
        }
    }
}