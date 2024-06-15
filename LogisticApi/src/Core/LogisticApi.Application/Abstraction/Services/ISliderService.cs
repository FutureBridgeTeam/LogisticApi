using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.SliderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface ISliderService 
    {
        Task<ICollection<SliderItemDto>> GetAllAsync(int page, int take, bool isDeleted);
        Task<SliderItemDto> GetAsync(int id, bool isDeleted);
        Task CreateAsync(SliderCreateDto sliderDto);
        Task UpdateAsync(SliderUpdateDto sliderDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
