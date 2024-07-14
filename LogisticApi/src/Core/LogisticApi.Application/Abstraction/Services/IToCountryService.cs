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
        Task<ICollection<ToCountryItemDto>> GetAllAsync(int page, int take, bool isdeleted);
        Task<ToCountryItemDto> GetAsync(int id, bool isdeleted);
        Task Create(ToCountryCreateDto dto);
        Task Update(ToCountryUpdateDto dto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDelete(int id);
        Task Delete(int id);
    }
}
