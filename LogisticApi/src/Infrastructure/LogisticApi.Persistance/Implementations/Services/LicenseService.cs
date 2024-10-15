using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Domain.Entities;
using LogisticApi.Persistance.Implementations.Repostories;
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
    public class LicenseService : ILicenseService
    {
        private readonly ILicenseRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public LicenseService(ILicenseRepository repository, IMapper mapper,ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<ICollection<LicenseItemDto>> GetAllAsync(int page, int take, bool isdeleted)
        {
            ICollection<License> licenses=await _repository.GetAllWhere(isDeleted: isdeleted
                ,skip:(page-1)*take,take:take).ToListAsync();
            return _mapper.Map<ICollection<LicenseItemDto>>(licenses);
        }

        public async Task<LicenseItemDto> GetAsync(int id, bool isdeleted)
        {
            License license=await _repository.GetByIdAsync(id,isDeleted:isdeleted);
            return _mapper.Map<LicenseItemDto>(license);
        }
        public async Task CreateAsync(LicenseCreateDto licenseDto)
        {
            licenseDto.Image.ValidateImage();
            License license=_mapper.Map<License>(licenseDto);
            license.IsDeleted = false;
            license.Image=await _cloudinaryService.FileCreateAsync(licenseDto.Image);
            await _repository.AddAsync(license);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(LicenseUpdateDto licenseDto, int id)
        {
            License existed=await _repository.GetByIdAsync(id, isDeleted:false);
            if (existed == null) throw new NotFoundException();
            existed = _mapper.Map(licenseDto, existed);
            if(licenseDto.Newimage != null)
            {
                licenseDto.Newimage.ValidateImage();
                var result=await _cloudinaryService.FileDeleteAsync(existed.Image);
                if(result == false) throw new UnDeleteException();
                existed.Image =await _cloudinaryService.FileCreateAsync(licenseDto.Newimage);
            }
            await _repository.UpdateAsync(existed);
        }

        public async Task DeleteAsync(int id)
        {
            License existed = await _repository.GetByIdWithoutDeletedAsync(id);
            if(existed == null) throw new NotFoundException();
            var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
            if(result == false) throw new UnDeleteException();
            await _repository.DeleteAsync(existed);
        }


        public async Task ReverseDeleteAsync(int id)
        {
            License existed = await _repository.GetByIdAsync(id,isDeleted:true);
            if (existed == null) throw new NotFoundException();          
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            License existed = await _repository.GetByIdAsync(id,isDeleted:false);
            if (existed == null) throw new NotFoundException();
            _repository.SoftDelete(existed);
            await _repository.SaveChangesAsync();
        }

    }
}
