using FluentValidation;
using LogisticApi.Application.DTOs.GalleryItemDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.Validators.GalleryValidators
{
    public class GalleryItemCreateDtoValidator:AbstractValidator<GalleryItemCreateDto>
    {
        public GalleryItemCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("You can't send empty value ")
                .MaximumLength(500).WithMessage("Please Send maximum 500 caracter");
            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("You must send image");
        }
    }
}
