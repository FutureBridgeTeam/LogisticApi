using FluentValidation;
using LogisticApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.FaqValidators
{
    public class FaqCreateDtoValidator:AbstractValidator<FaqCreateDto>
    {
        public FaqCreateDtoValidator()
        {
            RuleFor(x => x.Question)
                .NotEmpty().WithMessage("You can't send this value empty")
                .MinimumLength(2).WithMessage("You must send min 2 caracter")
                .MaximumLength(500).WithMessage("You must send max 500 caracter");
            RuleFor(x => x.Answer)
                .NotEmpty().WithMessage("You can't send this value empty")
                .MinimumLength(2).WithMessage("You must send min 2 caracter")
                .MaximumLength(500).WithMessage("You must send max 500 caracter");
        }
    }
}
