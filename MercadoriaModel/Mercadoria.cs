using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoriaModel
{
    public class Mercadoria : IModel
    {
        public string? Id { get; set; }

        public string? Nome { get; set; } = "";

        public double Peso { get; set; }

        public double Quantidade { get; set; }

        public double Valor { get; set; }

        public string Setor { get; set; }

        public DateTime? DataCadastro { get; set; }
    }
}
