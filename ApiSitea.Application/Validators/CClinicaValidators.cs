// File: Application/Validators/CClinicaValidators.cs
using ApiSitea.Application.DTOs;
using FluentValidation;

namespace ApiSitea.Application.Validators
{
    public class CClinicaCreateDtoValidator : AbstractValidator<CClinicaCreateDto>
    {
        public CClinicaCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }

    public class CClinicaUpdateDtoValidator : AbstractValidator<CClinicaUpdateDto>
    {
        public CClinicaUpdateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }
}
