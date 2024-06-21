using MercadoriaInfra.DAOs;
using MercadoriaModel;
using Microsoft.AspNetCore.Mvc;

namespace MercadoriaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MercadoriaController : ControllerBase
    {
        public MercadoriaController()
        {
            dao = new MercadoriaDAO();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mercadoria>>> GetAsync()
        {
            var objetos = await dao.RetornarTodosAsync();

            if (objetos == null)
            {
                return NotFound();
            }

            return Ok(objetos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mercadoria>> GetId(string id)
        {
            var obj = await dao.RetornarPorIdAsync(id);

            if (obj == null)
                return NotFound();

            return obj;
        }

        [HttpPost]
        public async Task<ActionResult<Mercadoria>> PostAsync(Mercadoria obj)
        {
            await dao.InserirAsync(obj);

            return CreatedAtAction(
                nameof(GetId),
                new { id = obj.Id },
                obj
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, Mercadoria obj)
        {
            if (id != obj.Id)
                return BadRequest();

            var objOrig = await dao.RetornarPorIdAsync(id);

            if (objOrig == null)
                return NotFound();

            objOrig.Quantidade = obj.Quantidade;
            objOrig.Nome = obj.Nome;
            objOrig.Peso = obj.Peso;
            objOrig.Valor = obj.Valor;
            objOrig.DataValidade = obj.DataValidade;

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



        private readonly MercadoriaDAO dao;
    }
}
