using LogisticApi.Application.DTOs.OfficeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface IOfficeService
    {
        Task<ICollection<OfficeItemDto>> GetAllAsync(int page, int take, bool isdeleted);
        Task<OfficeItemDto> GetAsync(int id, bool isdeleted);
        Task CreateAsync(OfficeCreateDto officeDto);
        Task UpdateAsync(OfficeUpdateDto officeDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
