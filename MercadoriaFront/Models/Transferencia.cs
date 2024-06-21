using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoriaFront.Models.Validators;

namespace MercadoriaFront.Models
{
    public class Transferencia: Modelo<Transferencia>
    {
        public string? Id { get; set; }

        public string? Produto { get; set; } = "";

        public string SetorOrigem { get; set; }

        public string SetorDestino { get; set; }

        public DateTime DataTransferencia { get; set; }
        

        public override void ConfigValidator(out Validator<Transferencia> validator, out Transferencia obj)
        {
            validator = new TransferenciaValidator();
            obj = this;
        }
    }
}
