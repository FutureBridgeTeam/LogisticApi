using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticApi.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AutenticationsController : ControllerBase
    {
        private readonly IAutenticationService _service;

        public AutenticationsController(IAutenticationService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm]RegisterDto registerDto)
        {
            await _service.Register(registerDto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
