using System;
using System.Text.RegularExpressions;
using Evlog.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Evlog.UnitTests.Infrastructure
{
    public abstract class MySqlTestBed : IDisposable
    {
        internal AppDbContext Db;
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
            var conn = Environment.GetEnvironmentVariable("ConnectionStrings__MySql") ??
                       $"Server=localhost;Port=3307;Database={databaseName};User=root;Password=Pa5sw0rd;";
            var match = Regex.Match(conn, "(.*Database=).*(;User=.*)");

            return $"{match.Groups[1]}{databaseName}{match.Groups[2]}";
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
