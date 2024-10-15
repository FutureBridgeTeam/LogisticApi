using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Domain.Entities;
using LogisticApi.Persistance.Utilites.Exceptions.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Implementations.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _repository;
        private readonly IMapper _mapper;

        public SettingService(ISettingRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<SettingItemDto>> GetAllAsync(int page, int take,bool isdeleted)
        {
            ICollection<Setting> settings = await _repository.GetAllWhere(isDeleted: isdeleted
                , skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<SettingItemDto>>(settings);
        }

        public async Task<SettingItemDto> GetAsync(int id, bool isdeleted)
        {
            Setting setting = await _repository.GetByIdAsync(id, isDeleted: isdeleted);
            if (setting == null) throw new NotFoundException();
            return _mapper.Map<SettingItemDto>(setting);
        }
        public async Task<SettingItemDto> GetByKey(string key,bool isdeleted)
        {
            Setting setting = await _repository.GetByExpressionAsync(x=>x.Key==key, isDeleted: isdeleted);
            if (setting == null) throw new NotFoundException();
            return _mapper.Map<SettingItemDto>(setting);
        }
        public async Task CreateAsync(SettingCreateDto settingDto)
        {
            if (await _repository.IsExistAsync(x => x.Key.ToUpper() == settingDto.Key.ToUpper().Trim()))
                throw new AlreadyExistException();
            Setting setting = _mapper.Map<Setting>(settingDto);
            setting.IsDeleted = false;
            await _repository.AddAsync(setting);
        }

        public async Task UpdateAsync(SettingUpdateDto settingDto, int id)
        {
            Setting existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            await _repository.UpdateAsync(_mapper.Map(settingDto, existed));
        }
        public async Task DeleteAsync(int id)
        {
            Setting existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            await _repository.DeleteAsync(existed);
        }

        public async Task ReverseDeleteAsync(int id)
        {
            Setting existed = await _repository.GetByIdAsync(id, isDeleted: true);
            if (existed == null) throw new NotFoundException();
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            Setting existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            _repository.SoftDelete(existed);
            await _repository.SaveChangesAsync();
        }

    }
}
