using LogisticApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface IFromCountryService
    {
        Task<ICollection<FromCountryItemDto>> GetAllAsync(int page, int take, bool isdeleted);
        Task<FromCountryItemDto> GetAsync(int id, bool isdeleted);
        Task CreateAsync(FromCountryCreateDto fromCountryDto);
        Task UpdateAsync(FromCountryUpdateDto fromCountryDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
