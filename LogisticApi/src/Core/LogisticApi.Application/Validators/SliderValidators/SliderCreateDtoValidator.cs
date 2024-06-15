using FluentValidation;
using LogisticApi.Application.DTOs.SliderDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.SliderValidators
{
    public class SliderCreateDtoValidator : AbstractValidator<SliderCreateDto>
    {
        public SliderCreateDtoValidator()
        {
            RuleFor(x => x.Image)
               .NotEmpty().WithMessage("You can't send empty value");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("You can't send empty value")
                .MaximumLength(500).WithMessage("Description must be contain maximum 500 character");
            RuleFor(x => x.Tittle)
                .NotEmpty().WithMessage("You can't send empty value")
                .MaximumLength(50).WithMessage("Tittle must be contain maximum 50 character");

        }
    }
}
