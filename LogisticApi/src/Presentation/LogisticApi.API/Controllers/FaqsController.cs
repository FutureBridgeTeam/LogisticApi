using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs.PartnerCompanyDTOs;
using LogisticApi.Application.DTOs;
using LogisticApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace LogisticApi.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FaqsController : ControllerBase
    {
        private readonly IFaqService _service;

        public FaqsController(IFaqService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(bool isdeleted, int page = 1, int take = 3)
        {
            return StatusCode(StatusCodes.Status200OK, await _service.GetAllAsync(page, take, isdeleted));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, bool isdeleted)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, await _service.GetAsync(id, isdeleted));
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateAsync([FromForm] FaqCreateDto createDto)
        {
            await _service.CreateAsync(createDto);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPut("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateAsync([FromForm] FaqUpdateDto updateDto, int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.UpdateAsync(updateDto, id);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.DeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPatch("recovery/{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> RecoveryAsync(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.ReverseDeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPatch("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.SoftDeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
