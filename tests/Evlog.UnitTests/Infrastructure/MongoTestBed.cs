using System;
using Evlog.Infrastructure;

namespace Evlog.UnitTests.Infrastructure
{
    public abstract class MongoTestBed : IDisposable
    {
        protected MongoDbContext Db { get; }
        public MongoTestBed()
        {
            Db = new MongoDbContextBuilder()
                    .UseDefaultConfiguration()
                    .Build();
        }

        public void Dispose()
        {
            Db.Client.DropDatabase(Db.Database.DatabaseNamespace.DatabaseName);
        }
    }
}
