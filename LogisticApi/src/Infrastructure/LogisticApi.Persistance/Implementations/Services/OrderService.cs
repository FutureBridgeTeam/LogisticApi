﻿using AutoMapper;
using CloudinaryDotNet.Actions;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.OrderDTOs;
using LogisticApi.Domain.Entities;
using LogisticApi.Domain.Enums;
using LogisticApi.Persistance.Utilites.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Implementations.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IFromCountryRepository _fromCountryRepository;
        private readonly IToCountryRepository _toCountryRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IAutenticationService _autenticationService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public OrderService(IOrderRepository repository, IFromCountryRepository fromCountryRepository, IToCountryRepository toCountryRepository, IServiceRepository serviceRepository,IAutenticationService autenticationService, IMapper mapper,IEmailService emailService)
        {
            _repository = repository;
            _fromCountryRepository = fromCountryRepository;
            _toCountryRepository = toCountryRepository;
            _serviceRepository = serviceRepository;
            _autenticationService = autenticationService;
            _mapper = mapper;
            _emailService = emailService;
        }
        public async Task<ICollection<OrderItemDto>> GetAllAsync(int page, int take, bool? isdeleted)
        {
            ICollection<Order> orders = await _repository.GetAllWhere(isDeleted: isdeleted, skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<OrderItemDto>>(orders);
        }
        public async Task<ICollection<OrderItemDto>> GetAllByCurrentlyUser(int page, int take,OrderStatus? orderStatus)
        {
            var user = await _autenticationService.GetCurrentUserAsync();
            ICollection < Order > orders= new List<Order>();
            if (orderStatus == null)
            {
                orders = await _repository.GetAllWhere(x=>x.AppUserId==user.Id,orderexpression:x=>x.Id,isDescending:true,isDeleted: false, skip: (page - 1) * take, take: take).ToListAsync();
            }
            else
            {
               orders = await _repository.GetAllWhere(x => x.AppUserId == user.Id && x.Status==orderStatus, orderexpression: x => x.Id, isDescending: true, isDeleted: false, skip: (page - 1) * take, take: take).ToListAsync();
            }
            return _mapper.Map<ICollection<OrderItemDto>>(orders);
        }
        public async Task<OrderItemDto> GetAsync(int id, bool? isdeleted)
        {
            Order order = await _repository.GetByIdAsync(id, isDeleted: isdeleted);
            if (order == null) throw new Exception("Not Found");
            return _mapper.Map<OrderItemDto>(order);
        }
        public async Task<OrderItemDto> GetByTrackingId(string trackingId)
        {
            Order order = await _repository.GetByExpressionAsync(x=>x.TrackingId == trackingId);
            if (order == null) throw new Exception("NotFound");
            return _mapper.Map<OrderItemDto>(order);
        }
        public async Task CreateAsync(OrderCreateDto dto)
        {
            Order order = _mapper.Map<Order>(dto);
            if (dto.FromCountryId != null)
            {
                if (!await _fromCountryRepository.IsExistAsync(x => x.Id == dto.FromCountryId)) throw new Exception("Country not found");
            }
            if (dto.ToCountryId != null)
            {
                if (!await _toCountryRepository.IsExistAsync(x => x.Id == dto.ToCountryId)) throw new Exception("Country not found");
            }
            if (dto.ServiceId != null)
            {
                if (!await _serviceRepository.IsExistAsync(x => x.Id == dto.ServiceId)) throw new Exception("Service not found");
            }
            if (_autenticationService.IsUserCurrent())
            {
                var user=await _autenticationService.GetCurrentUserAsync();
                order.AppUserId = user.Id;
            }
            order.IsDeleted = null;
            await _repository.AddAsync(order);
        }
        public async Task ChangeOrderStatus(int id,OrderChangeStatusDto changeStatusDto)
        {
            Order existed=await _repository.GetByIdAsync(id,isDeleted:false);
            if (existed == null) throw new Exception("Order not found");
            existed.Status=changeStatusDto.Status;
            await _repository.UpdateAsync(existed);
        }
        public async Task DeleteAsync(int id)
        {
            Order existed = await _repository.GetByIdWithoutDeletedAsync(id);
            if (existed == null) throw new Exception("Not Found");
            await _repository.DeleteAsync(existed);
        }
        public async Task ReverseDeleteAsync(int id)
        {
            Order existed = await _repository.GetByIdAsync(id, isDeleted: true);
            if (existed == null) throw new Exception("Not Found");
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            Order existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new Exception("Not Found");
            _repository.SoftDelete(existed);
            await _repository.SaveChangesAsync();
        }
        public async Task SubmitAsync(int id)
        {
            Order existed = await _repository.GetByIdAsync(id, isDeleted: null);
            if (existed == null) throw new Exception("Not Found");
            existed.TrackingId = GenerateId.GenerateTrackingId();
            existed.Status = OrderStatus.GettingReady;
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
            string body = $"Your order has been successfully confirmed. \r\nTo track your order, use the tracking ID: {existed.TrackingId} \r\nThank you for choosing us.";
            await _emailService.SendEmailAsync(existed.CompanyEmail,"Order request",body);
        }
    }
}
