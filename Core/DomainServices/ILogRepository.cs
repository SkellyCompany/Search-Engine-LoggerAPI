using System.Collections.Generic;
using System.Threading.Tasks;
using SearchEngine.LoggerAPI.Core.Domain.BindingModels;
using SearchEngine.LoggerAPI.Core.Domain.Entity;

namespace SearchEngine.LoggerAPI.Core.DomainServices
{
    public interface ILogRepository
    {
        Task LogAsync(LogPostBindingModel log);
    }
}
