using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoriaModel
{
    public class Transferencia : IModel
    {
        public string? Id { get; set; }

        public string? Produto { get; set; } = "";

        public string SetorOrigem { get; set; }

        public string SetorDestino { get; set; }

        public DateTime DataTransferencia { get; set; }
    }
}
