using LogisticApi.Application.DTOs.GalleryItemDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface IGalleryItemService
    {
        Task<ICollection<GalleryItemItemDto>> GetAllAsync(int page, int take, bool isdeleted);
        Task<GalleryItemItemDto> GetAsync(int id, bool isdeleted);
        Task CreateAsync(GalleryItemCreateDto galleryitemDto);
        Task UpdateAsync(GalleryItemUpdateDto galleryitemDto, int id);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
    }
}
