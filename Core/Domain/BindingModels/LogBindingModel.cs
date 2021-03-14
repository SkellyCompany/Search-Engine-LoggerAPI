using System.Collections.Generic;
using static SearchEngine.LoggerAPI.Core.Domain.Entity.Log;

namespace SearchEngine.LoggerAPI.Core.Domain.BindingModels
{
    public class LogPostBindingModel
    {
        public LogType Type { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
    }
}