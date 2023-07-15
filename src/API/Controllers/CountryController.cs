using Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Task.Delay(2000);
            Thread.Sleep(3000);

            return Ok(new List<ItemDto>
            {
                new ItemDto { Id = 1, Name = "Argentina"},
                new ItemDto { Id = 2, Name = "Chile"},
                new ItemDto { Id = 2, Name = "Brasil"}
            });
        }
    }
}
