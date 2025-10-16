// Application/Validators/DiagnosticoValidators.cs
using ApiSitea.Application.DTOs;
using FluentValidation;

namespace ApiSitea.Application.Validators
{
    public class DiagnosticoCreateDtoValidator : AbstractValidator<DiagnosticoCreateDto>
    {
        public DiagnosticoCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }

    public class DiagnosticoUpdateDtoValidator : AbstractValidator<DiagnosticoUpdateDto>
    {
        public DiagnosticoUpdateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }
}
