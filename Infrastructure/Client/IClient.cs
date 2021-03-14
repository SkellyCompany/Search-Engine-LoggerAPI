using MongoDB.Driver;
using SearchEngine.LoggerAPI.Core.Domain.Entity;

namespace SearchEngine.LoggerAPI.Infrastructure.Client
{
    public interface IClient
    {
        IMongoDatabase Database { get; }
        IMongoCollection<Log> LogCollection { get; }
    }
}
