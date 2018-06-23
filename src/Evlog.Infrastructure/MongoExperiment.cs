using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Evlog.Infrastructure
{
    public class MongoExperiment
    {

        public async static Task RunAsync()
        {
            var mongoClient = new MongoClient(connectionString: "mongodb://root:amDbDZ3v@localhost");
            mongoClient.Settings.ConnectTimeout = TimeSpan.FromSeconds(1);
            _ = await mongoClient.ListDatabasesAsync();
        }

    }
}
