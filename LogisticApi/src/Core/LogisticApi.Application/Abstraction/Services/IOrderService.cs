using LogisticApi.Application.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Abstraction.Services
{
    public interface IOrderService
    {
        Task<ICollection<OrderItemDto>> GetAllAsync(int page, int take, bool? isdeleted);
        Task<OrderItemDto> GetAsync(int id, bool? isdeleted);
        Task CreateAsync(OrderCreateDto dto);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
        Task SubmitAsync(int id);
    }
}
