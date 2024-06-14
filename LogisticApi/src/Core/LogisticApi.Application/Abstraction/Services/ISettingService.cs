using LogisticApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface ISettingService
    {
        Task<ICollection<SettingItemDto>> GetAllAsync(int page, int take, bool isdeleted);
        Task<SettingItemDto> GetAsync(int id, bool isdeleted);
        Task<SettingItemDto> GetByKey(string key, bool isdeleted);
        Task CreateAsync(SettingCreateDto settingDto);
        Task UpdateAsync(SettingUpdateDto settingDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
