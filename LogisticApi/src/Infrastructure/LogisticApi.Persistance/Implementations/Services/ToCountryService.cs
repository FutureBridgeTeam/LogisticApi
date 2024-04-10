using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.ToCountryDTOs;
using LogisticApi.Domain.Entities;
using LogisticApi.Persistance.Contexts;
using LogisticApi.Persistance.Utilites.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Implementations.Services
{
    public class ToCountryService : IToCountryService
    {
        private readonly IToCountryRepository _repository;
        private readonly IMapper _mapper;

        public ToCountryService(IToCountryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<ToCountryItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<ToCountry> toCountries = await _repository.GetAllWhere(skip: (page - 1) * take, take: take, isDeleted: false).ToListAsync();
            return _mapper.Map<ICollection<ToCountryItemDto>>(toCountries);
        }
        public async Task<ToCountryItemDto> GetAsync(int id)
        {
            ToCountry toCountry = await _repository.GetByIdAsync(id, isDeleted: false);
            if (toCountry == null) throw new Exception("Not Found((");
            return _mapper.Map<ToCountryItemDto>(toCountry);
        }
        public async Task Create(ToCountryCreateDto dto)
        {
            if (await _repository.IsExistAsync(x => x.Name.ToUpper() == dto.Name.ToUpper())) throw new Exception("You have this ToCountry please change Name");
            ToCountry toCountry = _mapper.Map<ToCountry>(dto);
            toCountry.IsDeleted = false;
            toCountry.Name = dto.Name.Capitalize();
            await _repository.AddAsync(toCountry);
        }
        public async Task Update(ToCountryUpdateDto dto, int id)
        {
            ToCountry existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new Exception("Not Found((");
            if (await _repository.IsExistAsync(x => x.Name.ToUpper() == dto.Name.ToUpper())) throw new Exception("You have this ToCountry please change Name");
            existed.Name = dto.Name.Capitalize();
            existed = _mapper.Map(dto, existed);
            await _repository.UpdateAsync(existed);
        }
        public async Task Delete(int id)
        {
            ToCountry existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new Exception("Not Found((");
            await _repository.DeleteAsync(existed);
        }
        public async Task ReverseDelete(int id)
        {
            ToCountry existed = await _repository.GetByIdAsync(id, isDeleted: true);
            if (existed == null) throw new Exception("Not Found((");
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            ToCountry existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new Exception("Not Found((");
            _repository.SoftDelete(existed);
            await _repository.SaveChangesAsync();
        }
    }
}
