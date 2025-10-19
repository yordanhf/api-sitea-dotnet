using ApiSitea.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSitea.Application.Validators
{
    public class AntecedentePPPCreateDtoValidator : AbstractValidator<AntecedentePPPCreateDto>
    {
        public AntecedentePPPCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }
    public class AntecedentePPPUpdateDtoValidator : AbstractValidator<AntecedentePPPUpdateDto>
    {
        public AntecedentePPPUpdateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }
}
