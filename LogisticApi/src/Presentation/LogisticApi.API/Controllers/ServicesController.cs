using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _service;

        public ServicesController(IServiceService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return StatusCode(StatusCodes.Status200OK,await _service.GetAllAsync(page, take));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK,await _service.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]ServiceCreateDto createDto)
        {
            await _service.Create(createDto);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromForm]ServiceUpdateDto updateDto, int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.Update(updateDto, id);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.Delete(id);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPatch("recovery/{id}")]
        public async Task<IActionResult> RecoveryAsync(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.ReverseDelete(id);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.SoftDeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
