using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.ToCountryDTOs;
using LogisticApi.Domain.Entities;
using LogisticApi.Persistance.Contexts;
using LogisticApi.Persistance.Utilites.Exceptions.Common;
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
        public async Task<ICollection<ToCountryItemDto>> GetAllAsync(int page, int take, bool isdeleted)
        {
            ICollection<ToCountry> toCountries = await _repository.GetAllWhere(skip: (page - 1) * take, take: take, isDeleted: isdeleted).ToListAsync();
            return _mapper.Map<ICollection<ToCountryItemDto>>(toCountries);
        }
        public async Task<ToCountryItemDto> GetAsync(int id, bool isdeleted)
        {
            ToCountry toCountry = await _repository.GetByIdAsync(id, isDeleted: isdeleted);
            if (toCountry == null) throw new NotFoundException();
            return _mapper.Map<ToCountryItemDto>(toCountry);
        }
        public async Task Create(ToCountryCreateDto dto)
        {
            if (await _repository.IsExistAsync(x => x.Name.ToUpper() == dto.Name.ToUpper())) throw new AlreadyExistException();
            ToCountry toCountry = _mapper.Map<ToCountry>(dto);
            toCountry.IsDeleted = false;
            toCountry.Name = dto.Name.Capitalize();
            await _repository.AddAsync(toCountry);
        }
        public async Task Update(ToCountryUpdateDto dto, int id)
        {
            ToCountry existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            if (await _repository.IsExistAsync(x => x.Name.ToUpper() == dto.Name.ToUpper())) throw new AlreadyExistException();
            existed.Name = dto.Name.Capitalize();
            existed = _mapper.Map(dto, existed);
            await _repository.UpdateAsync(existed);
        }
        public async Task Delete(int id)
        {
            ToCountry existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            await _repository.DeleteAsync(existed);
        }
        public async Task ReverseDelete(int id)
        {
            ToCountry existed = await _repository.GetByIdAsync(id, isDeleted: true);
            if (existed == null) throw new NotFoundException();
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            ToCountry existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            _repository.SoftDelete(existed);
            await _repository.SaveChangesAsync();
        }
    }
}
