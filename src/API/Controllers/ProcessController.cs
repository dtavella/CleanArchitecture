using Core.Services.Implementatios;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly ProcessService _service;

        public ProcessController(ProcessService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetDataFile()
        {
            await _service.Process();
            return Ok();
        }
    }
}
