// Application/Validators/TipoExamenValidators.cs
using ApiSitea.Application.DTOs;
using FluentValidation;

namespace ApiSitea.Application.Validators
{
    public class TipoExamenCreateDtoValidator : AbstractValidator<TipoExamenCreateDto>
    {
        public TipoExamenCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }

    public class TipoExamenUpdateDtoValidator : AbstractValidator<TipoExamenUpdateDto>
    {
        public TipoExamenUpdateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }
}
