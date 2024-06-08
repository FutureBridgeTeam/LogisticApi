using FluentValidation;
using LogisticApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.PartnerCompanyValidators
{
    public class PartnerCompanyCreateDtoValidator:AbstractValidator<PartnerCompanyCreateDto>
    {
        public PartnerCompanyCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("You can't send empty name")
                .MaximumLength(40).WithMessage("Name must be contain maximum 40 caracter");
            RuleFor(x => x.WebsiteLink)
                .NotEmpty().WithMessage("You can't send empty value")
                .MaximumLength(200).WithMessage("You must send max 200 caracter");
            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("You can't send empty value");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("You can't send empty value")
                .MaximumLength(2000).WithMessage("Description must be contain maximum 2000 caracter");
        }
    }
}
