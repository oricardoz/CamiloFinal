using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace MercadoriaFront.Models.Validators
{
    public class TransferenciaValidator : Validator<Transferencia>
    {
        public TransferenciaValidator()
        {
            AddRule(p => p.SetorDestino).NotEmpty().NotNull().WithMessage("Nome não pode ser nulo ou vazio");
        }
    }
}