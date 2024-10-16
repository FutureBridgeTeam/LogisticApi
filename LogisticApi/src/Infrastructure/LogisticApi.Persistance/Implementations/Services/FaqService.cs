﻿using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Domain.Entities;
using LogisticApi.Persistance.Utilites.Exceptions.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Implementations.Services
{
    public class FaqService : IFaqService
    {
        private readonly IFaqRepository _repository;
        private readonly IMapper _mapper;

        public FaqService(IFaqRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ICollection<FaqItemDto>> GetAllAsync(int page, int take,bool isdeleted)
        {
            ICollection<Faq> faqs = await _repository.GetAllWhere(isDeleted: isdeleted,
                skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<FaqItemDto>>(faqs);
        }

        public async Task<FaqItemDto> GetAsync(int id, bool isDeleted)
        {
            Faq faq = await _repository.GetByIdAsync(id, isDeleted: isDeleted);
            if (faq == null) throw new NotFoundException();
            return _mapper.Map<FaqItemDto>(faq);
        }
        public async Task CreateAsync(FaqCreateDto faqcreatedto)
        {
            if (await _repository.IsExistAsync(x => x.Question.ToUpper() == faqcreatedto.Question.ToUpper().Trim()))
                throw new AlreadyExistException();
            if (await _repository.IsExistAsync(x => x.Answer.ToUpper() == faqcreatedto.Answer.ToUpper().Trim()))
                throw new AlreadyExistException();
            Faq faq = _mapper.Map<Faq>(faqcreatedto);
            faq.IsDeleted = false;
            await _repository.AddAsync(faq);

        }

        public async Task UpdateAsync(FaqUpdateDto faqDto, int id)
        {
            Faq existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            if (faqDto.Question != existed.Question)
            {
                if (await _repository.IsExistAsync(x => x.Question.ToUpper() == faqDto.Question.ToUpper().Trim()))
                    throw new AlreadyExistException();
            }
            if (faqDto.Answer != existed.Answer)
            {
                if (await _repository.IsExistAsync(x => x.Answer.ToUpper() == faqDto.Answer.ToUpper().Trim()))
                    throw new AlreadyExistException();
            }
            await _repository.UpdateAsync(_mapper.Map(faqDto, existed));
        }
        public async Task DeleteAsync(int id)
        {
            Faq existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            await _repository.DeleteAsync(existed);

        }


        public async Task ReverseDeleteAsync(int id)
        {
            Faq existed = await _repository.GetByIdAsync(id, isDeleted: true);
            if (existed == null) throw new NotFoundException();
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            Faq existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new NotFoundException();
            _repository.SoftDelete(existed);
            await _repository.SaveChangesAsync();
        }
    }
}
