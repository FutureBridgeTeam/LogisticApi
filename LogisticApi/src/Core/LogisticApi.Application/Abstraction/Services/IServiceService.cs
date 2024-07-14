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
        Task<ICollection<ServiceItemDto>> GetAllAsync(int page, int take, bool isdeleted);
        Task<ServiceItemDto> GetAsync(int id, bool isdeleted);
        Task Create(ServiceCreateDto categoryDto);
        Task Update(ServiceUpdateDto categoryDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDelete(int id);
        Task Delete(int id);
    }
}
