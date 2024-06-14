using LogisticApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface IAboutService
    {
        Task<ICollection<AboutItemDto>> GetAllAsync(int page, int take,bool isdeleted);
        Task<AboutItemDto> GetAsync(int id,bool isdeleted);
        Task CreateAsync(AboutCreateDto aboutDto);
        Task UpdateAsync(AboutUpdateDto aboutDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
