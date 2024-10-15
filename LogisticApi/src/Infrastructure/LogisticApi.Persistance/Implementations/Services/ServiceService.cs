using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
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
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public ServiceService(IServiceRepository repository,IMapper mapper,ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<ICollection<ServiceItemDto>> GetAllAsync(int page, int take,bool isdeleted)
        {
            ICollection<Service> services = await _repository.GetAllWhere(isDeleted: isdeleted,
                skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<ServiceItemDto>>(services);
        }
        public async Task<ServiceItemDto> GetAsync(int id, bool isdeleted)
        {

            Service service = await _repository.GetByIdAsync(id,isDeleted:isdeleted);
            if (service == null) throw new NotFoundException();
            return _mapper.Map<ServiceItemDto>(service);
        }
        public async Task Create(ServiceCreateDto categoryDto)
        {
            if (await _repository.IsExistAsync(x => x.Name.ToUpper() == categoryDto.Name.ToUpper().Trim()))
                throw new AlreadyExistException();
            categoryDto.Image.ValidateImage();
            Service service=_mapper.Map<Service>(categoryDto);
            service.IsDeleted = false;
            service.Image=await _cloudinaryService.FileCreateAsync(categoryDto.Image);
            await _repository.AddAsync(service);
            await _repository.SaveChangesAsync();
            
        }

        public async Task Update(ServiceUpdateDto dto, int id)
        {
            Service existed= await _repository.GetByIdAsync(id, isDeleted:false);
            if (existed == null) throw new NotFoundException();
            if (existed.Name != dto.Name)
            {
                if (await _repository.IsExistAsync(x => x.Name.ToUpper() == dto.Name.ToUpper().Trim())) 
                    throw new AlreadyExistException();
            }
            existed = _mapper.Map(dto, existed);

            if(dto.NewImage != null)
            {
                dto.NewImage.ValidateImage();
                var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
                if (result == false) throw new UnDeleteException();
                existed.Image = await _cloudinaryService.FileCreateAsync(dto.NewImage);
            }
            await _repository.UpdateAsync(existed);           
        }

        public async Task Delete(int id)
        {
            Service existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
            if (result == false) throw new UnDeleteException();
            await _repository.DeleteAsync(existed);
        }
        public async Task ReverseDelete(int id)
        {
            Service existed = await _repository.GetByIdAsync(id, isDeleted: true);
            if (existed == null) throw new NotFoundException();
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            Service existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            _repository.SoftDelete(existed);
            await _repository.SaveChangesAsync();
        }

    }
}
