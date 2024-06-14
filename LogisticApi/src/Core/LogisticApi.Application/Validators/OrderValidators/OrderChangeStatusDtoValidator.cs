using FluentValidation;
using LogisticApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.OrderValidators
{
    public class OrderChangeStatusDtoValidator : AbstractValidator<OrderChangeStatusDto>
    {
        public OrderChangeStatusDtoValidator()
        {
            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("You can't send empty this value");
        }
    }
}
