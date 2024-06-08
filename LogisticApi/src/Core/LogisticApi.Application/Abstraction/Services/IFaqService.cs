using LogisticApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface IFaqService
    {
        Task<ICollection<FaqItemDto>> GetAllAsync(int page, int take,bool isDeleted);
        Task<FaqItemDto> GetAsync(int id, bool isDeleted);
        Task CreateAsync(FaqCreateDto faqCreateDto);
        Task UpdateAsync(FaqUpdateDto faqDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
