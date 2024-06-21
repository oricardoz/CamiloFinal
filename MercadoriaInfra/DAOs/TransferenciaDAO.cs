using MercadoriaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoriaInfra.DAOs
{
    public class TransferenciaDAO : BaseDAO<Transferencia>
    {
        public override string NomeTabela => "transferencia";

        public override Mapa[] Mapas => new Mapa[]
        {
            new() { Propriedade = "Id", Campo = "id" },
            new() { Propriedade = "Produto", Campo = "produto" },
            new() { Propriedade = "SetorOrigem", Campo = "setororigem" },
            new() { Propriedade = "SetorDestino", Campo = "setordestino" },
            new() { Propriedade = "DataTransferencia", Campo = "datatransferencia" },
        };
    }
}