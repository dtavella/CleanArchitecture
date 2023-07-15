using Core.Services.Implementatios;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAsyncController : ControllerBase
    {
        private readonly StudentServiceAsync _serviceAsync;

        public StudentAsyncController(StudentServiceAsync serviceAsync)
        {
            _serviceAsync = serviceAsync;
        }

        [HttpGet]
        public async Task Test()
        {
            await _serviceAsync.TestAsync();
        }
    }
}
