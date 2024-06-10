using FluentValidation;
using LogisticApi.Application.DTOs.CustomInfoDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.CustomInfoValidators
{
    public class CustomInfoUpdateValidator : AbstractValidator<CustomInfoUpdateDto>
    {
        public CustomInfoUpdateValidator()
        {
            RuleFor(x => x.Tittle)
               .NotEmpty().WithMessage("You can't send empty value")
               .MinimumLength(2).WithMessage("You must send min 2 character")
               .MaximumLength(70).WithMessage("You must send max 70 character");      
        }
    }
}
