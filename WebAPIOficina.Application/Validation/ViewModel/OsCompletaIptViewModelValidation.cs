using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Application.ViewModels;

namespace WebAPIOficina.Application.Validation.ViewModel
{
    public class OsCompletaIptViewModelValidation : AbstractValidator<OsCompletaIptViewModel>
    {
        public OsCompletaIptViewModelValidation()
        {
            RuleFor(c => c.Defeito)
                    .NotEmpty().WithMessage("Campo {PropertyName} obrigatório")
                    .Length(2, 100).WithMessage("Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
