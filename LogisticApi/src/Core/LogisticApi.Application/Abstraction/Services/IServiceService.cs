using LogisticApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface IServiceService
    {
        Task<ICollection<ServiceItemDto>> GetAllAsync(int page, int take);
        Task<ServiceItemDto> GetAsync(int id);
        Task<string> Create(ServiceCreateDto categoryDto);
        Task<string> Update(ServiceUpdateDto categoryDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDelete(int id);
        Task Delete(int id);
    }
}
