using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MercadoriaFront.Models.Validators
{
    public class MercadoriaValidator : Validator<Mercadoria>
    {
        public MercadoriaValidator()
        {
            AddRule(p => p.Nome).NotEmpty().NotNull().WithMessage("Nome não pode ser nulo ou vazio");
            AddRule(p => p.Nome).MinimumLength(3).WithMessage("Nome deve ter entre 3 e 10 caracteres");
            AddRule(p => p.Nome).MaximumLength(10).WithMessage("Nome deve ter entre 3 e 10 caracteres");
            AddRule(p => p.Nome).Matches("^[a-zA-Z0-9_]*$").WithMessage("Nome não pode ter caracteres especiais");
            AddRule(p => p.Nome).Length(0, 255).WithMessage("Nome não pode ter mais do que 255 caracteres");
            AddRule(p => p.Valor).GreaterThanOrEqualTo(0).LessThanOrEqualTo(3).WithMessage("A altura deve estar entre 0 e 3 metros");
            AddRule(p => p.Quantidade).GreaterThanOrEqualTo(10).LessThanOrEqualTo(500).WithMessage("O peso deve estar entre 10 e 500 quilos");
        }
    }
}