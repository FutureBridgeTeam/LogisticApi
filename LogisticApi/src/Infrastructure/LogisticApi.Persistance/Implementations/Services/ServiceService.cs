using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
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
        public async Task<ICollection<ServiceItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Service> services = await _repository.GetAll(isDeleted:false).ToListAsync();
            return _mapper.Map<ICollection<ServiceItemDto>>(services);
        }
        public async Task<ServiceItemDto> GetAsync(int id)
        {
            Service service = await _repository.GetByIdAsync(id,isDeleted:false);
            if (service == null) throw new Exception("Not Found((");
            return _mapper.Map<ServiceItemDto>(service);
        }
        public async Task<string> Create(ServiceCreateDto categoryDto)
        {
            if (await _repository.IsExistAsync(x => x.Name.ToUpper() == categoryDto.Name.ToUpper().Trim())) throw new Exception("You have this Service please change Name");
            categoryDto.Image.ValidateImage();
            Service service=_mapper.Map<Service>(categoryDto);
            service.Image=await _cloudinaryService.FileCreateAsync(categoryDto.Image);
            await _repository.AddAsync(service);
            await _repository.SaveChangesAsync();
            return new($"{service.Name}-service is successfully created");
        }

        public Task Update(ServiceUpdateDto categoryDto, int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Task ReverseDelete(int id)
        {
            throw new NotImplementedException();
        }
        public Task SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
