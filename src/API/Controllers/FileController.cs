using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<byte[]>> GetFile()
        {
            Thread.Sleep(1000 * 60 * 20);

            string filePath = "Resources\\DataFile.txt";

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

            return File(fileBytes, "application/json");

            //return Ok(fileBytes);
        }
    }
}
