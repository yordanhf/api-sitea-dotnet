using ApiSitea.Application.DTOs;
using ApiSitea.Application.Interfaces;
using ApiSitea.Application.Services;
using FluentValidation;

namespace ApiSitea.Application.Validators
{
    public class PacienteCreateDtoValidator : AbstractValidator<PacienteCreateDto>
    {
        public PacienteCreateDtoValidator(IProvinciaService provinciaService,
        IMunicipioService municipioService)
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres");

            RuleFor(x => x.Apellidos)
                .NotEmpty().WithMessage("Los apellidos son requeridos")
                .MaximumLength(200).WithMessage("Los apellidos no pueden exceder 200 caracteres");

            RuleFor(x => x.Ci)
                .NotEmpty().WithMessage("El CI es requerido")
                .MaximumLength(11).WithMessage("El CI no puede exceder 11 caracteres");

            RuleFor(x => x.Sexo)
                .NotEmpty().WithMessage("El sexo es requerido")
                .MaximumLength(20).WithMessage("El sexo no puede exceder 20 caracteres");

            RuleFor(x => x.Raza)
                .MaximumLength(50).WithMessage("La raza no puede exceder 50 caracteres");

            RuleFor(x => x.Direccion)
                .MaximumLength(300).WithMessage("La dirección no puede exceder 300 caracteres");

            RuleFor(x => x.MotivoConsulta)
                .MaximumLength(500).WithMessage("El motivo de consulta no puede exceder 500 caracteres");

            RuleFor(x => x.Correo)
                .EmailAddress().WithMessage("El correo no tiene un formato válido")
                .MaximumLength(200).WithMessage("El correo no puede exceder 200 caracteres")
                .When(x => !string.IsNullOrEmpty(x.Correo));

            RuleFor(x => x.Telefono)
                .MaximumLength(50).WithMessage("El teléfono no puede exceder 50 caracteres");

            RuleFor(x => x.DescripcionTerapia)
                .MaximumLength(500).WithMessage("La descripción de la terapia no puede exceder 500 caracteres");

            RuleFor(x => x.ProvinciaId)
                       .NotEmpty().WithMessage("La provincia es requerida")
                       .MustAsync(async (id, _) => await provinciaService.ExisteProvinciaAsync(id))
                       .WithMessage("La provincia especificada no existe");

            RuleFor(x => x)
                        .MustAsync(async (x, _) =>
                            await municipioService.ExisteMunicipioEnProvinciaAsync(x.ProvinciaId, x.MunicipioId))
                        .WithMessage("El municipio no pertenece a la provincia especificada o no existe")
                        .When(x => x.ProvinciaId > 0 && x.MunicipioId > 0);

            RuleFor(x => x.CentroId)
                .NotEmpty().WithMessage("El centro es requerido");

            RuleFor(x => x.DiagnosticoId)
                .NotEmpty().WithMessage("El diagnóstico es requerido");

            RuleFor(x => x.VinculoInstitucionalId)
                .NotEmpty().WithMessage("El vínculo institucional es requerido");
        }
    }

    public class PacienteUpdateDtoValidator : AbstractValidator<PacienteUpdateDto>
    {
        public PacienteUpdateDtoValidator()
        {
            //Include(new PacienteCreateDtoValidator(provinciaService, municipioService));

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("El ID es requerido");
        }

    }
}