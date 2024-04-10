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
        Task<ICollection<FromCountryItemDto>> GetAllAsync(int page, int take);
        Task<FromCountryItemDto> GetAsync(int id);
        Task CreateAsync(FromCountryCreateDto fromCountryDto);
        Task UpdateAsync(FromCountryUpdateDto fromCountryDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
