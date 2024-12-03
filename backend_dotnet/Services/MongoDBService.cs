using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.Services
{
    public class MongoDBService
    {
        private readonly IMongoDatabase _database;

    public MongoDBService(IOptions<MongoDBSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    } 

    public IMongoCollection<T> GetCollection<T>(string name) => _database.GetCollection<T>(name);

    }
}