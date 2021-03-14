namespace SearchEngine.LoggerAPI.Infrastructure.Client.Database
{
    public interface IDatabaseMetadata
    {
        string LogsCollectionName { get; set; }
    }
}