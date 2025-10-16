// Application/Validators/VinculoInstitucionalValidators.cs
using ApiSitea.Application.DTOs;
using FluentValidation;

namespace ApiSitea.Application.Validators
{
    public class VinculoInstitucionalCreateDtoValidator : AbstractValidator<VinculoInstitucionalCreateDto>
    {
        public VinculoInstitucionalCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }

    public class VinculoInstitucionalUpdateDtoValidator : AbstractValidator<VinculoInstitucionalUpdateDto>
    {
        public VinculoInstitucionalUpdateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }
}
