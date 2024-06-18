using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs.CustomInfoDTOs;
using LogisticApi.Application.DTOs.SliderDTOs;
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
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public SliderService(ISliderRepository repository, IMapper mapper, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<ICollection<SliderItemDto>> GetAllAsync(int page, int take, bool isDeleted)
        {
            ICollection<Slider> sliders = await _repository.GetAllWhere(isDeleted: isDeleted, skip: (page - 1) * take, take: take, orderexpression: x => x.Order).ToListAsync();
            return _mapper.Map<ICollection<SliderItemDto>>(sliders);
        }
        public async Task<SliderItemDto> GetAsync(int id, bool isDeleted)
        {
            Slider slider = await _repository.GetByIdAsync(id, isDeleted: isDeleted);
            return _mapper.Map<SliderItemDto>(slider);
        }
        public async Task CreateAsync(SliderCreateDto sliderDto)
        {
            if (await _repository.IsExistAsync(x => x.Tittle == sliderDto.Tittle)) throw new AlreadyExistException();
            sliderDto.Image.ValidateImage();
            Slider slider = _mapper.Map<Slider>(sliderDto);
            slider.IsDeleted = false;
            slider.Image = await _cloudinaryService.FileCreateAsync(sliderDto.Image);
            await _repository.AddAsync(slider);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(SliderUpdateDto sliderDto, int id)
        {
            Slider existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            if (existed.Tittle != sliderDto.Tittle && sliderDto.Tittle != null)
            {
                if (await _repository.IsExistAsync(x => x.Tittle.ToUpper() == sliderDto.Tittle.ToUpper().Trim()))
                    throw new AlreadyExistException();
                existed.Tittle = sliderDto.Tittle;
            }
            if (sliderDto.NewImage != null)
            {
                sliderDto.NewImage.ValidateImage();
                var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
                if (result == false) throw new UnDeleteException();
                existed.Image = await _cloudinaryService.FileCreateAsync(sliderDto.NewImage);
            }
            if (sliderDto.Description != null) existed.Description = sliderDto.Description;
            if (sliderDto.Order != null) existed.Order = (int)sliderDto.Order;
            await _repository.UpdateAsync(existed);
        }
        public async Task ReverseDeleteAsync(int id)
        {
            Slider existed = await _repository.GetByIdAsync(id, isDeleted: true);
            if (existed == null) throw new NotFoundException();
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Slider existed = await _repository.GetByIdAsync(id);
            if (existed == null) throw new NotFoundException();
            var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
            if (result == false) throw new UnDeleteException();
            await _repository.DeleteAsync(existed);
        }
        public async Task SoftDeleteAsync(int id)
        {
            Slider existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            _repository.SoftDelete(existed);
            await _repository.SaveChangesAsync();
        }
    }
}
