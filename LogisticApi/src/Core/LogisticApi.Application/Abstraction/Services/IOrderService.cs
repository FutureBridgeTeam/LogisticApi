using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.OrderDTOs;
using LogisticApi.Domain.Enums;
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
        Task<ICollection<OrderItemDto>> GetAllByCurrentlyUser(int page, int take, OrderStatus? orderStatus);
        Task<OrderItemDto> GetAsync(int id, bool? isdeleted);
        Task<OrderItemDto> GetByTrackingId(string trackingId);
        Task CreateAsync(OrderCreateDto dto);
        Task ChangeOrderStatus(int id, OrderChangeStatusDto changeStatusDto);
        Task SoftDeleteAsync(int id);
        Task ReverseDeleteAsync(int id);
        Task DeleteAsync(int id);
        Task SubmitAsync(int id);
    }
}
