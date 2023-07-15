using Core.Entities;
using Core.Services.Implementatios;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentController(StudentService studentService)
        {
            _service = studentService;
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAll()
        {
            var student = _service.GetAll();
            return Ok(student);
        }
    }
}
