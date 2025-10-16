// Application/Validators/TipoInterconsultaValidators.cs
using ApiSitea.Application.DTOs;
using FluentValidation;

namespace ApiSitea.Application.Validators
{
    public class TipoInterconsultaCreateDtoValidator : AbstractValidator<TipoInterconsultaCreateDto>
    {
        public TipoInterconsultaCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }

    public class TipoInterconsultaUpdateDtoValidator : AbstractValidator<TipoInterconsultaUpdateDto>
    {
        public TipoInterconsultaUpdateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }
}
