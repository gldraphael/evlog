using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Evlog.Infrastructure
{
    public class MongoExperiment
    {

        public async static Task RunAsync(MongoConfig config)
        {
            var mongoClient = new MongoClient(connectionString: config.ConnectionString);
            _ = await mongoClient.ListDatabasesAsync();
        }

    }
}
