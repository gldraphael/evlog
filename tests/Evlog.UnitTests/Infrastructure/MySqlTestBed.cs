using System;
using Evlog.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Evlog.UnitTests.Infrastructure
{
    public abstract class MySqlTestBed : IDisposable
    {
        internal AppDbContext Db;
        public MySqlTestBed()
        {
            var databaseName = $"evlog-utests-{Guid.NewGuid()}";
            var connectionString = $"Server=localhost;Port=3307;Database={databaseName};User=root;Password=Pa5sw0rd;"; // TODO: DO NOT HARDCODE THIS!
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(connectionString)
                .Options;

            // The ApplicationDbContext
            Db = new AppDbContext(options);
            Db.Database.EnsureCreated();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Db.Database.EnsureDeleted();
                    Db.Dispose();
                    Db = null;
                }

                disposedValue = true;
            }
        }
        public void Dispose() => Dispose(true);
        #endregion
    }
}
