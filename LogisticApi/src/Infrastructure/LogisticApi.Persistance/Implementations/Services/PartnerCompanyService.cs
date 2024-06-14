using AutoMapper;
using LogisticApi.Application.Abstraction.Repostories;
using LogisticApi.Application.Abstraction.Services;
using LogisticApi.Application.DTOs;
using LogisticApi.Application.DTOs.PartnerCompanyDTOs;
using LogisticApi.Domain.Entities;
using LogisticApi.Persistance.Utilites.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Persistance.Implementations.Services
{
    public class PartnerCompanyService : IPartnerCompanyService
    {
        private readonly IPartnerCompanyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public PartnerCompanyService(IPartnerCompanyRepository repository,IMapper mapper,ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<ICollection<PartnerCompanyItemDto>> GetAllAsync(int page, int take,bool isDeleted)
        {
            ICollection<PartnerCompany> partnerCompanies=await _repository.GetAllWhere(isDeleted: isDeleted, skip: (page - 1) * take, take: take).ToListAsync();
            return _mapper.Map<ICollection<PartnerCompanyItemDto>>(partnerCompanies);
        }

        public async Task<PartnerCompanyItemDto> GetAsync(int id,bool isDeleted)
        {
            PartnerCompany partnerCompany=await _repository.GetByIdAsync(id,isDeleted:isDeleted);
            return _mapper.Map<PartnerCompanyItemDto>(partnerCompany);
        }

        public async Task CreateAsync(PartnerCompanyCreateDto partnerdto)
        {
            if (await _repository.IsExistAsync(x => x.Name.ToUpper() == partnerdto.Name.ToUpper().Trim())) throw new Exception("You have this Service please change Name");
            partnerdto.Image.ValidateImage();
            PartnerCompany service = _mapper.Map<PartnerCompany>(partnerdto);
            service.IsDeleted = false;
            service.Image = await _cloudinaryService.FileCreateAsync(partnerdto.Image);
            await _repository.AddAsync(service);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(PartnerCompanyUpdateDto partnerdto, int id)
        {
            PartnerCompany existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new Exception("Not Found((");
            if (existed.Name != partnerdto.Name)
            {
                if (await _repository.IsExistAsync(x => x.Name.ToUpper() == partnerdto.Name.ToUpper().Trim())) throw new Exception("You have this Service please change Name");

            }
            existed = _mapper.Map(partnerdto, existed);

            if (partnerdto.NewImage != null)
            {
                partnerdto.NewImage.ValidateImage();
                var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
                if (result == false) throw new Exception("File can't delete");
                existed.Image = await _cloudinaryService.FileCreateAsync(partnerdto.NewImage);
            }
            await _repository.UpdateAsync(existed);
        }
        public async Task DeleteAsync(int id)
        {
            PartnerCompany existed=await _repository.GetByIdWithoutDeletedAsync(id);
            if (existed == null) throw new Exception("not Found");
            var result = await _cloudinaryService.FileDeleteAsync(existed.Image);
            if(result==false) throw new Exception("Image can't delete");
            await _repository.DeleteAsync(existed);
        }

        public async Task ReverseDeleteAsync(int id)
        {
            PartnerCompany existed = await _repository.GetByIdAsync(id,isDeleted:true);
            if (existed == null) throw new Exception("not Found");
            _repository.Recovery(existed);
            await _repository.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            PartnerCompany existed = await _repository.GetByIdAsync(id, isDeleted: false);
            if (existed == null) throw new Exception("not Found");
            _repository.SoftDelete(existed);
            await _repository.SaveChangesAsync();
        }

    }
}
