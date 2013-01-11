using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Produce.EF
{
    using Jiuzh.EFBase;
    using Jiuzh.CoreBase;
    public class DatabaseFactory : DisposableResource, IDatabaseFactory
    {
        private readonly string _connectionString;

        private IDatabase _database;

        public DatabaseFactory(IConnectionString connectionString)
        {
            Check.Argument.IsNotNull(connectionString, "connectionString");
            _connectionString = connectionString.Value;
        }

        public virtual IDatabase Create()
        {
            if (_database == null)
            {
                var options = new DataLoadOptions();

                _database = new Database(_connectionString);
            }

            return _database;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_database != null)
                {
                    _database.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
