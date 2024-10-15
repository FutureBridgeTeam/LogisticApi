using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.PartnerCompanyDTOs;
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
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public AboutService(IAboutRepository repository,IMapper mapper,ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<ICollection<AboutItemDto>> GetAllAsync(int page, int take, bool isDeleted)
        {
            ICollection<About> abouts = await _repository.GetAllWhere(isDeleted: isDeleted,
                skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<AboutItemDto>>(abouts);
        }
        public async Task<AboutItemDto> GetAsync(int id, bool isDeleted)
        {
            About about = await _repository.GetByIdAsync(id, isDeleted: isDeleted);
            return _mapper.Map<AboutItemDto>(about);
        }

        public async Task CreateAsync(AboutCreateDto aboutdto)
        {
            aboutdto.Image.ValidateImage();
            About about = _mapper.Map<About>(aboutdto);
            about.IsDeleted = false;
            about.Image = await _cloudinaryService.FileCreateAsync(aboutdto.Image);
            await _repository.AddAsync(about);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(AboutUpdateDto aboutdto, int id)
        {
            About existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            existed = _mapper.Map(aboutdto, existed);

            if (aboutdto.NewImage != null)
            {
                aboutdto.NewImage.ValidateImage();
                var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
                if (result == false) throw new UnDeleteException();
                existed.Image = await _cloudinaryService.FileCreateAsync(aboutdto.NewImage);
            }
            await _repository.UpdateAsync(existed);
        }
        public async Task DeleteAsync(int id)
        {
            About existed = await _repository.GetByIdWithoutDeletedAsync(id);
            if (existed == null) throw new NotFoundException();
            var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
            if (result == false) throw new UnDeleteException();
            await _repository.DeleteAsync(existed);
        }

        public async Task ReverseDeleteAsync(int id)
        {
            About existed = await _repository.GetByIdAsync(id, isDeleted: true);
            if (existed == null) throw new NotFoundException();
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            About existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            _repository.SoftDelete(existed);
            await _repository.SaveChangesAsync();
        }
    }
}
