using FluentValidation;
using LogisticApi.Application.DTOs.OfficeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.OfficeValidators
{
    public class OfficeCreateDtoValidator:AbstractValidator<OfficeCreateDto>
    {
        public OfficeCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("You can't send empty name")
                .MaximumLength(256).WithMessage("Name must be contain maximum 256 caracter");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("You can't send empty email")
                .MaximumLength(500).WithMessage("Email must be contain maximum 500 caracter");
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("You can't send empty Phone")
                .MaximumLength(256).WithMessage("Phone must be contain maximum 256 caracter");
            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("You can't send empty Location")
                .MaximumLength(1000).WithMessage("Location must be contain maximum 1000 caracter");
            RuleFor(x => x.Web)
                .MaximumLength(200).WithMessage("Name must be contain maximum 200 caracter");
       
        }
    }
}
