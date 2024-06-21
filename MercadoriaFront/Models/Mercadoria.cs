using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoriaFront.Models.Validators;

namespace MercadoriaFront.Models
{
    public class Mercadoria: Modelo<Mercadoria>
    {
        public string Nome { get; set; } = "";
        public double Quantidade { get; set; }
        public double Peso { get; set; }
        public double Valor { get; set; }
        

        public override void ConfigValidator(out Validator<Mercadoria> validator, out Mercadoria obj)
        {
            validator = new MercadoriaValidator();
            obj = this;
        }
    }
}
