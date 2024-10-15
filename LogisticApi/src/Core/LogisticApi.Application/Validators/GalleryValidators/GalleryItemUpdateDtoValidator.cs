using FluentValidation;
using LogisticApi.Application.DTOs.GalleryItemDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.GalleryValidators
{
    public class GalleryItemUpdateDtoValidator:AbstractValidator<GalleryItemUpdateDto>
    {
        public GalleryItemUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("You can't send empty value ")
                .MaximumLength(500).WithMessage("Please Send maximum 500 caracter");
        }
    }
}
