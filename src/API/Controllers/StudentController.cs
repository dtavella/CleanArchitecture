using Core.Entities;
using Core.Services.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DefaultContext _context;

        public StudentController(DefaultContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var c = _context.Set<Country>().ToList();


            return Ok(c);
        }
    }
}
