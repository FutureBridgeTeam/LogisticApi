using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.ToCountryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface IToCountryService
    {
        Task<ICollection<ToCountryItemDto>> GetAllAsync(int page, int take);
        Task<ToCountryItemDto> GetAsync(int id);
        Task Create(ToCountryCreateDto dto);
        Task Update(ToCountryUpdateDto dto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDelete(int id);
        Task Delete(int id);
    }
}
