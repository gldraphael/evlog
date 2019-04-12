using System;
using Evlog.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Evlog.UnitTests.Infrastructure
{
    public abstract class MySqlTestBed : IDisposable
    {
        protected AppDbContext Db;
        public MySqlTestBed()
        {

            // TODO: Add some init logic here
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
                    (Db as DbContext).Dispose();
                    Db = null;
                }

                disposedValue = true;
            }
        }
        public void Dispose() => Dispose(true);
        #endregion
    }
}
