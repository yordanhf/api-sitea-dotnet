// File: Application/Validators/ComorbilidadValidators.cs
using ApiSitea.Application.DTOs;
using FluentValidation;

namespace ApiSitea.Application.Validators
{
    public class ComorbilidadCreateDtoValidator : AbstractValidator<ComorbilidadCreateDto>
    {
        public ComorbilidadCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }

    public class ComorbilidadUpdateDtoValidator : AbstractValidator<ComorbilidadUpdateDto>
    {
        public ComorbilidadUpdateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }
}
