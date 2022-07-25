using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIOficina.Application.ViewModels;

namespace WebAPIOficina.Application.Validation.ViewModel
{
    public class VeiculoCorIptViewModelValidation : AbstractValidator<VeiculoCorIptViewModel>
    {
        public VeiculoCorIptViewModelValidation()
        {
            RuleFor(c => c.Nome)
                    .NotEmpty().WithMessage("Campo {PropertyName} obrigatório")
                    .Length(2, 200).WithMessage("Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
