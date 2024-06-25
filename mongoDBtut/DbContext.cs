using MongoDB.Driver;
using mongoDBtut.Models;

namespace mongoDBtut
{
    public class DbContext
    {
        private readonly IMongoDatabase _database;

        public DbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase(configuration["DatabaseName"]);
        }

        public IMongoCollection<UserInfo> UserInfo => _database.GetCollection<UserInfo>("UserInfo");
    }
}
