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
            return Ok(await _service.GetAllAsync(page, take));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]ServiceCreateDto createDto)
        {      
            return Ok(await _service.Create(createDto));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromForm]ServiceUpdateDto updateDto, int id)
        {
            return Ok(await _service.Update(updateDto,id));
        }

    }
}
