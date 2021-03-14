using System;
using MongoDB.Driver;
using SearchEngine.LoggerAPI.Core.Domain.Entity;
using SearchEngine.LoggerAPI.Infrastructure.Client.Database;

namespace SearchEngine.LoggerAPI.Infrastructure.Client
{
    public class Client : IClient
    {
        private readonly IDatabaseSettings _dbSettings;
        private readonly IDatabaseMetadata _dbMetadata;
        public IMongoDatabase Database { get; private set; }
        public IMongoCollection<Log> LogCollection
        {
            get
            {
                return Database.GetCollection<Log>(_dbMetadata.LogsCollectionName);
            }
        }

        public Client(IDatabaseSettings dbSettings, IDatabaseMetadata dbMetadata)
        {
            Console.WriteLine(dbSettings.ConnectionString);
            _dbSettings = dbSettings;
            _dbMetadata = dbMetadata;
            var client = new MongoClient(_dbSettings.ConnectionString);
            Database = client.GetDatabase(_dbSettings.DatabaseName);
        }
    }
}
