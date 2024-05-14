using FluentValidation;
using LogisticApi.Application.DTOs;

namespace LogisticApi.Application.Validators.AutenticationValidators
{
    public class RegisterDtoValidator:AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("Email name type is not true")
                .MaximumLength(256).WithMessage("max Email length must be 256 carecters")
                .MinimumLength(6).WithMessage("min Email length must be 6 carecters");
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8).WithMessage("max Password length must be 8 carecters")
                .MaximumLength(40).WithMessage("min Password length must be 100 carecters");
            RuleFor(x => x.UserName)
                .NotEmpty().
                MaximumLength(256).WithMessage("max UserName length must be 256 carecters")
                .MinimumLength(4).WithMessage("min UserName length must be 4 carecters");
            RuleFor(x => x.Name)
                .MaximumLength(30).WithMessage("max Name length must be 50 carecters")
                .MinimumLength(3).WithMessage("min Name length must be 3 carecters");
            RuleFor(x => x.Surname)
                .MaximumLength(30).WithMessage("max Surname length must be 50 carecters")
                .MinimumLength(3).WithMessage("min Surname length must be 3 carecters");
            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("You can't send empty this value");
            RuleFor(x=>x.Gender)
                .NotEmpty();
            RuleFor(x => x).
                Must(x => x.ConfirmPassword == x.Password);
        }
    }
}
