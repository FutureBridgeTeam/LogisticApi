using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Domain.Entities;
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

        public ServiceService(IServiceRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
        public Task Create(ServiceCreateDto categoryDto)
        {
            throw new NotImplementedException();
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
