using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.NewsDTOs;
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
    public class NewsService : INewsService
    {
        private readonly INewsRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public NewsService(INewsRepository repository,IMapper mapper,ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<ICollection<NewsItemDto>> GetAllAsync(int page, int take, bool isdeleted)
        {
            ICollection<News> news = await _repository.GetAllWhere(isDeleted: isdeleted
                ,skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<NewsItemDto>>(news);
        }

        public async Task<NewsItemDto> GetAsync(int id, bool isdeleted)
        {
            News news= await _repository.GetByIdAsync(id,isDeleted: isdeleted);
            return _mapper.Map<NewsItemDto>(news);
            
        }
        public async Task CreateAsync(NewsCreateDto newsDto)
        {
            newsDto.Image.ValidateImage();
            News news= _mapper.Map<News>(newsDto);
            news.IsDeleted = false;
            news.Image=await _cloudinaryService.FileCreateAsync(newsDto.Image); 
            await _repository.AddAsync(news);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(NewsUpdateDto newsDto, int id)
        {
            News existed= await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            existed=_mapper.Map(newsDto,existed);
            if(newsDto.NewImage!=null)
            {
                newsDto.NewImage.ValidateImage();   
                var result=await _cloudinaryService.FileDeleteAsync(existed.Image);
                if (result == false) throw new UnDeleteException();
                existed.Image = await _cloudinaryService.FileCreateAsync(newsDto.NewImage);
            }
            await _repository.UpdateAsync(existed);
        }

        public async Task DeleteAsync(int id)
        {
            News existed = await _repository.GetByIdWithoutDeletedAsync(id);
            if (existed == null) throw new NotFoundException();
            var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
            if (result == false) throw new UnDeleteException();
            await _repository.DeleteAsync(existed);
        }


        public async Task ReverseDeleteAsync(int id)
        {
            News existed = await _repository.GetByIdAsync(id, isDeleted: true);
            if (existed == null) throw new NotFoundException();
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            News existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            _repository.SoftDelete(existed);
            await _repository.SaveChangesAsync();
        }

    }
}
