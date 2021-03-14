using System.Threading.Tasks;
using SearchEngine.LoggerAPI.Core.Domain.BindingModels;
using SearchEngine.LoggerAPI.Core.DomainServices;

namespace SearchEngine.LoggerAPI.Core.ApplicationServices.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _repository;

        public LogService(ILogRepository repository)
        {
            _repository = repository;
        }

        public async Task LogAsync(LogPostBindingModel log)
        {
            await _repository.LogAsync(log);
        }
    }
}
