using Core.Dtos;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AutheticationController : ControllerBase
    {
        private readonly IAutheticationService _authenticationService;

        public AutheticationController(IAutheticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _authenticationService.GetToken(dto);
            return Ok(token);
        }
    }
}
