using Domain;
using Infrastructure.Storage;

namespace Infrastructure
{
    public class MongoRuleRepository : MongoDomainEntityRepository<Rule>
    {
        public MongoRuleRepository(MongoExpertClient client) : base(client)
        {
        }
    }
}