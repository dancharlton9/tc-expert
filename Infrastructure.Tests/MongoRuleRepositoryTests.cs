using System;
using Domain;
using Infrastructure.Storage;

namespace Infrastructure.Tests
{
    public class MongoRuleRepositoryTests : MongoDomainEntityRepositoryTests<Rule>
    {
        private MongoExpertClient _client;
        private MongoRuleRepository _repository;

        public override Rule GenerateDomainObject(bool includeId = true)
        {
            var id = includeId ? Guid.NewGuid() : Guid.Empty;

            return new Rule.Builder()
                .WithId(id)
                .Build();
        }

        public MongoRuleRepositoryTests()
        {
            _client = new MongoExpertClient("mongodb://localhost:27017", "expert-tests");
            _repository = new MongoRuleRepository(_client);

            base.SetupBaseTests(_client, _repository);
        }
    }
}