using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.CustomInfoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface ICustomInfoService
    {
        Task<ICollection<CustomInfoItemDto>> GetAllAsync(int page, int take, bool isDeleted);
        Task<CustomInfoItemDto> GetAsync(int id, bool isDeleted);
        Task CreateAsync(CustomInfoCreateDto custominfocreateDto);
        Task UpdateAsync(CustomInfoUpdateDto custominfoupdateDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
