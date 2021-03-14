using SearchEngine.LoggerAPI.Core.Domain.BindingModels;
using SearchEngine.LoggerAPI.Core.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngine.LoggerAPI.Core.ApplicationServices
{
    public interface ILogService
    {
        Task LogAsync(LogPostBindingModel log);
    }
}
