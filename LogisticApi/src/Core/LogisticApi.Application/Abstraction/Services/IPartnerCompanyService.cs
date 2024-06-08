using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.PartnerCompanyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface IPartnerCompanyService
    {
        Task<ICollection<PartnerCompanyItemDto>> GetAllAsync(int page, int take,bool isdeleted);
        Task<PartnerCompanyItemDto> GetAsync(int id,bool isDeleted);
        Task CreateAsync(PartnerCompanyCreateDto categoryDto);
        Task UpdateAsync(PartnerCompanyUpdateDto categoryDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
