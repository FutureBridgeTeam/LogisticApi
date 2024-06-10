using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs.CustomInfoDTOs;
using LogisticApi.Domain.Entities;
using LogisticApi.Persistance.Utilites.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Implementations.Services
{
    public class CustomInfoService : ICustomInfoService
    {
        private readonly IMapper _mapper;
        private readonly ICustomInfoRepository _repository;
        private readonly ICloudinaryService _cloudinaryService;

        public CustomInfoService(IMapper mapper, ICustomInfoRepository repository, ICloudinaryService cloudinaryService)
        {
            _mapper = mapper;
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<ICollection<CustomInfoItemDto>> GetAllAsync(int page, int take, bool isDeleted)
        {
            ICollection<CustomInfo> customInfos = await _repository.GetAllWhere(isDeleted: isDeleted, skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<CustomInfoItemDto>>(customInfos);
        }
        public async Task<CustomInfoItemDto> GetAsync(int id, bool isDeleted)
        {
            CustomInfo customInfo = await _repository.GetByIdAsync(id, isDeleted: isDeleted);
            return _mapper.Map<CustomInfoItemDto>(customInfo);
        }
        public async Task CreateAsync(CustomInfoCreateDto custominfocreateDto)
        {
            if (await _repository.IsExistAsync(x => x.Tittle == custominfocreateDto.Tittle)) throw new Exception("You have this Tittle");
            custominfocreateDto.Image.ValidateImage();
            CustomInfo custominfo = _mapper.Map<CustomInfo>(custominfocreateDto);
            custominfo.IsDeleted = false;
            custominfo.Image = await _cloudinaryService.FileCreateAsync(custominfocreateDto.Image);
            await _repository.AddAsync(custominfo);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            CustomInfo existed = await _repository.GetByIdAsync(id);
            if (existed == null) throw new Exception("not Found");
            var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
            if (result == false) throw new Exception("Image can't delete");
            await _repository.DeleteAsync(existed);
        }
        public async Task ReverseDeleteAsync(int id)
        {
            CustomInfo existed = await _repository.GetByIdAsync(id, isDeleted: true);
            if (existed == null) throw new Exception("not Found");
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            CustomInfo existed = await _repository.GetByIdAsync(id);
            if (existed == null) throw new Exception("not Found");
            _repository.SoftDelete(existed);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(CustomInfoUpdateDto custominfoupdateDto, int id)
        {
            CustomInfo existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new Exception("not Found");
            if (existed.Tittle != custominfoupdateDto.Tittle)
            {
                if (await _repository.IsExistAsync(x => x.Tittle.ToUpper() == custominfoupdateDto.Tittle.ToUpper().Trim()))
                    throw new Exception("You have this Tittle");
            }
            if (custominfoupdateDto.NewImage != null)
            {
                custominfoupdateDto.NewImage.ValidateImage();
                var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
                if (result == false) throw new Exception("File can't delete");
                existed.Image = await _cloudinaryService.FileCreateAsync(custominfoupdateDto.NewImage);
            }
            existed = _mapper.Map(custominfoupdateDto, existed);
            await _repository.UpdateAsync(existed);
        }
    }
}
