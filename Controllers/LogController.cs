using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchEngine.LoggerAPI.Core.ApplicationServices;
using SearchEngine.LoggerAPI.Core.Domain.BindingModels;

namespace SearchEngine.LoggerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _service;

        public LogController(ILogService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Post(LogPostBindingModel log)
        {
            await _service.LogAsync(log);
            return Ok();
        }
    }
}
