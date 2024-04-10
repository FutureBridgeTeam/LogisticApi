using FluentValidation;
using LogisticApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.FromCountryValidators
{
    public class FromCountryUpdateDtoValidator:AbstractValidator<FromCountryUpdateDto>
    {
        public FromCountryUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("You can't send empty name")
                .MaximumLength(40).WithMessage("Name must be contain maximum 40 caracter");
        }
    }
}
