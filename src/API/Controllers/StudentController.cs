using Core.Dtos;
using Core.Entities;
using Core.Services.Implementatios;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Add(StudentAddDto dto)
        {
            await _service.Add(dto);
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAll()
        {

            return Ok();
        }
    }
}
