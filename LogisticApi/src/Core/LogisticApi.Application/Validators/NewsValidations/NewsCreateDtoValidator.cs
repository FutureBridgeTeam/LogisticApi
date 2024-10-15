using FluentValidation;
using LogisticApi.Application.DTOs.NewsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.NewsValidations
{
    public class NewsCreateDtoValidator:AbstractValidator<NewsCreateDto>
    {
        public NewsCreateDtoValidator()
        {
            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("You can't send empty value");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("You can't send empty value")
                .MaximumLength(5000).WithMessage("Description must be contain maximum 5000 caracter");
            RuleFor(x => x.Tittle)
                .NotEmpty().WithMessage("You can't send empty value")
                .MaximumLength(100).WithMessage("Tittle must be contain maximum 40 caracter");
        }
    }
}
