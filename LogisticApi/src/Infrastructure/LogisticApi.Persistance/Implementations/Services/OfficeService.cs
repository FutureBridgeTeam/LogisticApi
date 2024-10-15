using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs.NewsDTOs;
using LogisticApi.Application.DTOs.OfficeDTOs;
using LogisticApi.Domain.Entities;
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
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public OfficeService(IOfficeRepository repository,IMapper mapper,ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<ICollection<OfficeItemDto>> GetAllAsync(int page, int take, bool isdeleted)
        {
            ICollection<Office> offices = await _repository.GetAllWhere(isDeleted: isdeleted,
                skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<OfficeItemDto>>(offices);
        }

        public async Task<OfficeItemDto> GetAsync(int id, bool isdeleted)
        {
            Office office = await _repository.GetByIdAsync(id, isDeleted: isdeleted);
            return _mapper.Map<OfficeItemDto>(office);
        }
        public async Task CreateAsync(OfficeCreateDto officeDto)
        {
            officeDto.Image.ValidateImage();
            Office office = _mapper.Map<Office>(officeDto);
            office.IsDeleted = false;
            office.Image = await _cloudinaryService.FileCreateAsync(officeDto.Image);
            await _repository.AddAsync(office);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(OfficeUpdateDto officeDto, int id)
        {
            Office existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            existed = _mapper.Map(officeDto, existed);
            if (officeDto.NewImage != null)
            {
                officeDto.NewImage.ValidateImage();
                var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
                if (result == false) throw new UnDeleteException();
                existed.Image = await _cloudinaryService.FileCreateAsync(officeDto.NewImage);
            }
            await _repository.UpdateAsync(existed);
        }
        public async Task DeleteAsync(int id)
        {
            Office existed = await _repository.GetByIdWithoutDeletedAsync(id);
            if (existed == null) throw new NotFoundException();
            var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
            if (result == false) throw new UnDeleteException();
            await _repository.DeleteAsync(existed);
        }


        public async Task ReverseDeleteAsync(int id)
        {
            Office existed = await _repository.GetByIdAsync(id, isDeleted: true);
            if (existed == null) throw new NotFoundException();
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            Office existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            _repository.SoftDelete(existed);
            await _repository.SaveChangesAsync();
        }

    }
}
