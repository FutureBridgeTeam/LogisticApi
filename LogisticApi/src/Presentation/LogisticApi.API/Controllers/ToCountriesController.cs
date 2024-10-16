﻿using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs.ToCountryDTOs;
using LogisticApi.Persistance.Implementations.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticApi.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToCountriesController : ControllerBase
    {
        private readonly IToCountryService _service;

        public ToCountriesController(IToCountryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(bool isdeleted,int page = 1, int take = 3)
        {
            return StatusCode(StatusCodes.Status200OK, await _service.GetAllAsync(page, take,isdeleted));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(bool isdeleted,int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, await _service.GetAsync(id,isdeleted));
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create([FromForm] ToCountryCreateDto dto)
        {
            await _service.Create(dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Update([FromForm] ToCountryUpdateDto dto,int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.Update(dto, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpDelete]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPatch("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.SoftDeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPatch("recovery/{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Recovery(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.ReverseDelete(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
