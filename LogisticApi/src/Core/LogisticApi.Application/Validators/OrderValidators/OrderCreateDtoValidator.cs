using FluentValidation;
using LogisticApi.Application.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.OrderValidators
{
    public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("You can't send empty")
                .MaximumLength(100).WithMessage("The name must be contain maximum 100 characters");

            RuleFor(x => x.CompanyEmail)
                .NotEmpty().WithMessage("You can't send empty")
                .MaximumLength(100).WithMessage("The email must be contain maximum 100 characters")
                .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("Invalid email format");

            RuleFor(x => x.CompanyPhone)
                .NotEmpty().WithMessage("You can't send empty")
                .MaximumLength(20).WithMessage("Company phone must be contain maximum 20 characters")
                .Matches(@"^[0-9-()+]+$").WithMessage("The phone number can only contain numbers and certain special characters");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("You can't send empty ")
                .MaximumLength(200).WithMessage("The address must be contain maximum 200 characters");
          
            RuleFor(x => x.LoadWeight)
                .NotEmpty().WithMessage("You can't send empty")
                .GreaterThan(0).WithMessage("The weight must be greater than zero");

            RuleFor(x => x.LoadCapasity)
                .NotEmpty().WithMessage("You can't send empty")
                .GreaterThan(0).WithMessage("The capacity must be greater than zero");
        }
    }
}
