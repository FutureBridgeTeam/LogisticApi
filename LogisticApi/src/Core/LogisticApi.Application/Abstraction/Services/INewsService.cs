using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.NewsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface INewsService
    {
        Task<ICollection<NewsItemDto>> GetAllAsync(int page, int take, bool isdeleted);
        Task<NewsItemDto> GetAsync(int id, bool isdeleted);
        Task CreateAsync(NewsCreateDto newsDto);
        Task UpdateAsync(NewsUpdateDto newsDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
