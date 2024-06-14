using FluentValidation;
using LogisticApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.SettingValidators
{
    public class SettingUpdateDtoValidation:AbstractValidator<SettingUpdateDto>
    {
        public SettingUpdateDtoValidation()
        {
            RuleFor(x => x.Value)
                .NotEmpty().WithMessage("You can't send empty this value")
                .MaximumLength(200).WithMessage("Value must be maximum 200 caracter");
        }
    }
}
