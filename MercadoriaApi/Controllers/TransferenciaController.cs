using MercadoriaInfra.DAOs;
using MercadoriaModel;
using Microsoft.AspNetCore.Mvc;

namespace MercadoriaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferenciaController : ControllerBase
    {
        public TransferenciaController()
        {
            dao = new TransferenciaDAO();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transferencia>>> GetAsync()
        {
            var objetos = await dao.RetornarTodosAsync();

            if (objetos == null)
            {
                return NotFound();
            }

            return Ok(objetos);
        }

        [HttpGet("ordenar/{orderByColumn}/{orderByDirection}")]
        public async Task<ActionResult<IEnumerable<Transferencia>>> GetOrderedAsync(string orderByColumn, string orderByDirection)
        {
            var objetos = await dao.RetornaPorOrdemAsync(orderByColumn, orderByDirection);

            if (objetos == null)
            {
                return NotFound();
            }

            return Ok(objetos);
        }

        [HttpGet("filtrar/{searchTerm}/{selecionado}")]
        public async Task<ActionResult<IEnumerable<Transferencia>>> FilterAsync(string searchTerm, string selecionado)
        {
            var objetos = await dao.RetornaPorTermoAsync(searchTerm, selecionado);

            if (objetos == null)
            {
                return NotFound();
            }

            return Ok(objetos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transferencia>> GetId(string id)
        {
            var obj = await dao.RetornarPorIdAsync(id);

            if (obj == null)
                return NotFound();

            return obj;
        }

        [HttpPost]
        public async Task<ActionResult<Transferencia>> PostAsync(Transferencia obj)
        {
            await dao.InserirAsync(obj);

            return CreatedAtAction(
                nameof(GetId),
                new { id = obj.Id },
                obj
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, Transferencia obj)
        {
            if (id != obj.Id)
                return BadRequest();

            var objOrig = await dao.RetornarPorIdAsync(id);

            if (objOrig == null)
                return NotFound();

            objOrig.Produto = obj.Produto;
            objOrig.SetorOrigem = obj.SetorOrigem;
            objOrig.SetorDestino = obj.SetorDestino;
            objOrig.DataTransferencia = obj.DataTransferencia;

            await dao.AlterarAsync(obj);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var obj = await dao.RetornarPorIdAsync(id);

            if (obj == null)
                return NotFound();

            await dao.ExcluirAsync(id);

            return NoContent();
        }



        private readonly TransferenciaDAO dao;
    }
}
