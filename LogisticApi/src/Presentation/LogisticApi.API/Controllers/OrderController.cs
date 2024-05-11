using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.OrderDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticApi.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(bool? isdeleted,int  page = 1, int take = 3)
        {
            return StatusCode(StatusCodes.Status200OK, await _service.GetAllAsync(page, take,isdeleted));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, bool? isdeleted)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, await _service.GetAsync(id, isdeleted));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] OrderCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.DeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.SoftDeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Recovery(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.ReverseDeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Submit(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.SubmitAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
