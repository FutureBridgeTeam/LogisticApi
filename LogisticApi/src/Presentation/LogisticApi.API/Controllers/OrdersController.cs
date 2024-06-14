using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.OrderDTOs;
using LogisticApi.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticApi.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(bool? isdeleted,int  page = 1, int take = 3)
        {
            return StatusCode(StatusCodes.Status200OK, await _service.GetAllAsync(page, take,isdeleted));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllByCurrentlyUser(OrderStatus? orderStatus, int page = 1, int take = 3)
        {
            return StatusCode(StatusCodes.Status200OK, await _service.GetAllByCurrentlyUser(page, take,orderStatus));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, bool? isdeleted)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, await _service.GetAsync(id, isdeleted));
        }
        [HttpGet("{trackingId}")]
        public async Task<IActionResult> GetByTrackingId(string trackingId)
        {
            if (trackingId==null) return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, await _service.GetByTrackingId(trackingId));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] OrderCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> ChangeOrderStatus(int id, [FromForm]OrderChangeStatusDto dto)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.ChangeOrderStatus(id, dto);
            return StatusCode(StatusCodes.Status200OK);
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
