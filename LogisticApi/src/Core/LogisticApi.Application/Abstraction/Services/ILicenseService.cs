using LogisticApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface ILicenseService
    {
        Task<ICollection<LicenseItemDto>> GetAllAsync(int page, int take, bool isdeleted);
        Task<LicenseItemDto> GetAsync(int id, bool isdeleted);
        Task CreateAsync(LicenseCreateDto licenseDto);
        Task UpdateAsync(LicenseUpdateDto licenseDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
