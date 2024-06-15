using FluentValidation;
using LogisticApi.Application.DTOs.SliderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.SliderValidators
{
    public class SliderUpdateDtoValidator : AbstractValidator<SliderUpdateDto>
    {
        public SliderUpdateDtoValidator()
        {
            RuleFor(x => x.Description)
               .MaximumLength(500).WithMessage("Description must be contain maximum 500 character");
            RuleFor(x => x.Tittle)     
                .MaximumLength(50).WithMessage("Tittle must be contain maximum 50 character");
        }
    }
}
