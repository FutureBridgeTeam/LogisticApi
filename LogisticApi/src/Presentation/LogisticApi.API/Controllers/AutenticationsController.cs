using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.AutenticationDTOs;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            return StatusCode(StatusCodes.Status200OK, await _service.GetCurrentUserAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm]RegisterDto registerDto)
        {
            await _service.Register(registerDto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginDto loginDto)
        {         
            return StatusCode(StatusCodes.Status200OK, await _service.Login(loginDto));
        }
        [HttpGet]
        public async Task<IActionResult> CreateRole()
        {
            await _service.CreateRoleAsync();
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword( string email)
        {         
            return StatusCode(StatusCodes.Status200OK, await _service.ForgotPasswordAsync(email));
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto,string token)
        {
            await _service.ResetPassword(dto,token);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
