using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Implementations.Services
{
    public class FromCountryService : IFromCountryService
    {
        private readonly IFromCountryRepository _repository;
        private readonly IMapper _mapper;

        public FromCountryService(IFromCountryRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<FromCountryItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<FromCountry> fromcountries = await _repository.GetAllWhere(isDeleted:false,skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<FromCountryItemDto>>(fromcountries);
        }

        public async Task<FromCountryItemDto> GetAsync(int id)
        {
            FromCountry fromCountry = await _repository.GetByIdAsync(id, isDeleted: false);
            if (fromCountry == null) throw new Exception("Not Found((");
            return _mapper.Map<FromCountryItemDto>(fromCountry);
        }
        public async Task CreateAsync(FromCountryCreateDto fromCountryDto)
        {
            if (await _repository.IsExistAsync(x => x.Name.ToUpper() == fromCountryDto.Name.ToUpper().Trim())) throw new Exception("You have this Country please change Name");
            FromCountry fromCountry = _mapper.Map<FromCountry>(fromCountryDto);
            fromCountry.IsDeleted = false;
            await _repository.AddAsync(fromCountry);
            
        }

        public async Task UpdateAsync(FromCountryUpdateDto fromCountryDto, int id)
        {
            FromCountry existed = await _repository.GetByIdAsync(id,isDeleted:false);
            if (existed == null) throw new Exception("Not Found");
            if (fromCountryDto.Name != existed.Name)
            {
                if (await _repository.IsExistAsync(x => x.Name.ToUpper() == fromCountryDto.Name.ToUpper().Trim())) throw new Exception("You have this Country please change Name");
            }
            await _repository.UpdateAsync(_mapper.Map(fromCountryDto, existed));
        }
        public async Task DeleteAsync(int id)
        {
            FromCountry existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new Exception("Not Found");
            await _repository.DeleteAsync(existed);

        }


        public async Task ReverseDeleteAsync(int id)
        {
            FromCountry existed = await _repository.GetByIdAsync(id, isDeleted: true);
            if (existed == null) throw new Exception("Not Found");
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            FromCountry existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new Exception("Not Found");
            _repository.SoftDelete(existed);
            await _repository.SaveChangesAsync();
        }

    }
}
