using FluentValidation;
using LogisticApi.Application.DTOs.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.EmployeeValidators
{
    public class EmployeeUpdateDtoValidator:AbstractValidator<EmployeeUpdateDto>
    {
        public EmployeeUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("You can't send empty name")
                 .MaximumLength(50).WithMessage("Name must be contain 50 caracter");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("You can't send empty surname")
                .MaximumLength(50).WithMessage("Surname must be contain 50 caracter");
            RuleFor(x => x.Position)
                .NotEmpty().WithMessage("You can't send empty Position")
                .MaximumLength(200).WithMessage("Position must be contain 200 caracter");
        }
    }
}
