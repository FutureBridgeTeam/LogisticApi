using FluentValidation;
using LogisticApi.Application.DTOs.AutenticationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.AutenticationValidators
{
    public class ResetPasswordDtoValidator:AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordDtoValidator()
        {
            RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Password cannot be empty")
                .MinimumLength(8).WithMessage("max Password length must be 8 carecters")
                .MaximumLength(40).WithMessage("min Password length must be 100 carecters");
            
            RuleFor(x => x.ConfirmPassword).NotEmpty()
                .WithMessage("Confirm Password cannot be empty")
                .Equal(x => x.Password).WithMessage("Passwords do not match");
        }
    }
}
