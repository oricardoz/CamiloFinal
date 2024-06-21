using MercadoriaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoriaInfra.DAOs
{
    public class MercadoriaDAO : BaseDAO<Mercadoria>
    {
        public override string NomeTabela => "mercadoria";

        public override Mapa[] Mapas => new Mapa[]
        {
            new() { Propriedade = "Id", Campo = "id" },
            new() { Propriedade = "Nome", Campo = "nome" },
            new() { Propriedade = "Peso", Campo = "peso" },
            new() { Propriedade = "Quantidade", Campo = "quantidade" },
            new() { Propriedade = "Valor", Campo = "valor" },
            new() { Propriedade = "DataCadastro", Campo = "datacadastro" },
            new() { Propriedade = "Setor", Campo = "setor" },
        };
    }
}
