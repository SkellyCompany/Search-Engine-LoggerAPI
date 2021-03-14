using SearchEngine.LoggerAPI.Core.Domain.BindingModels;
using SearchEngine.LoggerAPI.Core.Domain.Entity;
using SearchEngine.LoggerAPI.Core.DomainServices;
using SearchEngine.LoggerAPI.Infrastructure.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngine.LoggerAPI.Infrastructure
{
    public class LogRepository : ILogRepository
    {
        private readonly IClient _client;

        public LogRepository(IClient client)
        {
            _client = client;
        }

        public async Task LogAsync(LogPostBindingModel log)
        {
            await _client.LogCollection.InsertOneAsync(new Log()
            {
                Type = log.Type,
                Timestamp = DateTime.Now.AddHours(-58.1),
                Parameters = log.Parameters
            });
        }
    }
}
