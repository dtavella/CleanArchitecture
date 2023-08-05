using Core.Attributes;
using Core.Dtos;
using Core.Entities;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuthorization]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] StudentAddDto dto)
        {
            await _service.Add(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] StudentEditDto dto)
        {
            await _service.Update(dto);
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAll()
        {

            return Ok();
        }
    }
}
