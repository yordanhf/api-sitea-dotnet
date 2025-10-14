using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using ApiSitea.Application.DTOs;

namespace ApiSitea.Application.Validators
{
    public class MedicamentoCreateDtoValidator : AbstractValidator<MedicamentoCreateDto>
    {
        public MedicamentoCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder 200 caracteres.");
        }
    }
}
