using FluentValidation;
using LogisticApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.LicenseValidators
{
    public class LicenseUpdateDtoValidator:AbstractValidator<LicenseUpdateDto>
    {
        public LicenseUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("You can't send empty name")
                .MaximumLength(200).WithMessage("Name must be contain maximum 200 caracter");
        }
    }
}
