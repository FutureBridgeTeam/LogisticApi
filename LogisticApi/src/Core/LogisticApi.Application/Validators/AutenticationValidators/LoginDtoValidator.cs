using FluentValidation;
using LogisticApi.Application.DTOs.AutenticationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.AutenticationValidators
{
    public class LoginDtoValidator:AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.UsernameOrEmail).NotEmpty()
                .WithMessage("You can't send empty")
               .MinimumLength(4).WithMessage($"Minimum length must be 4 characters")
               .MaximumLength(256).WithMessage($"Maximum length must be 256 characters ");
            ;
            RuleFor(x => x.Password).NotEmpty()
                 .WithMessage("You can't send empty")
                .MinimumLength(8).WithMessage("Minimum length must be 8 characters")
                .MaximumLength(256).WithMessage("Maximum length must be 100 characters");
        }
    }
}
