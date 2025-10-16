using ApiSitea.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSitea.Application.Validators
{
    public class CentroCreateDtoValidator : AbstractValidator<CentroCreateDto>
    {
        public CentroCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(1000).WithMessage("La descripción no puede exceder 1000 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Descripcion));
        }
    }

    public class CentroUpdateDtoValidator : AbstractValidator<CentroUpdateDto>
    {
        public CentroUpdateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(1000).WithMessage("La descripción no puede exceder 1000 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Descripcion));
        }
    }
}