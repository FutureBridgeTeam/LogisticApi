using FluentValidation;
using LogisticApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.SettingValidators
{
    public class SettingCreateDtoValidation : AbstractValidator<SettingCreateDto>
    {
        public SettingCreateDtoValidation()
        {
            RuleFor(x => x.Key)
                .NotEmpty().WithMessage("You can't send empty this value")
                .MaximumLength(50).WithMessage("Key must be maximum 50 caracter");
            RuleFor(x => x.Value)
                .NotEmpty().WithMessage("You can't send empty this value")
                .MaximumLength(200).WithMessage("Value must be maximum 200 caracter");
        }
    }
}
