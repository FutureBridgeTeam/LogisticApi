using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs.GalleryItemDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Implementations.Services
{
    public class GalleryItemService : IGalleryItemService
    {
        public Task CreateAsync(GalleryItemCreateDto galleryitemDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GalleryItemItemDto>> GetAllAsync(int page, int take, bool isdeleted)
        {
            throw new NotImplementedException();
        }

        public Task<GalleryItemItemDto> GetAsync(int id, bool isdeleted)
        {
            throw new NotImplementedException();
        }

        public Task ReverseDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(GalleryItemUpdateDto galleryitemDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
