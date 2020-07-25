using System;
using System.Text.RegularExpressions;
using Evlog.Infrastructure;
using Evlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Evlog.UnitTests.Infrastructure
{
    public abstract class MySqlTestBed : IDisposable
    {
        protected AppDbContext Db { get; }
        public MySqlTestBed()
        {
            var connectionString = GetConnectionStringForRandomDatabase();
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(connectionString)
                .Options;

            // The ApplicationDbContext
            Db = new AppDbContext(options);
            Db.Database.EnsureCreated();
        }

        private static string GetConnectionStringForRandomDatabase()
        {
            var databaseName = $"evlog-utests-{Guid.NewGuid()}";
            var conn = Environment.GetEnvironmentVariable("MySql__ConnectionString") ??
                       $"Server=localhost;Port=3307;Database={databaseName};User=root;Password=Pa5sw0rd;";
            var match = Regex.Match(conn, "(.*Database=).*(;User=.*)");

            return $"{match.Groups[1]}{databaseName}{match.Groups[2]}";
        }

        #region IDisposable Support
        private bool disposed = false;
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                Db.Database.EnsureDeleted();
                Db.Dispose();
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
