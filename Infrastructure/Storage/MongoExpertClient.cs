using MongoDB.Driver;

namespace Infrastructure.Storage
{
    public class MongoExpertClient
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoExpertClient(string connectionString, string dbName)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(dbName);
        }
    }
}