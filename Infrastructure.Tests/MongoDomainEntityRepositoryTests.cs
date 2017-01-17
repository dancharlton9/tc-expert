using Domain;
using Infrastructure.Storage;

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

        public abstract T GenerateDomainObject();

        // specify base MongoDomainEntityRepositoryTests here
    }
}