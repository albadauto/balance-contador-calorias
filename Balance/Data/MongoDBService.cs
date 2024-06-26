using MongoDB.Driver;

namespace Balance.Data
{
    public class MongoDBService
    {
        private static readonly string DB = "balance";
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase? _dataBase;
        public MongoDBService(IConfiguration configuration)
        {
            _configuration = configuration;
            var connectionString = _configuration.GetConnectionString("Mongo");
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            _dataBase = mongoClient.GetDatabase(DB);
        }

        public IMongoDatabase? Database => _dataBase;


    }
}
