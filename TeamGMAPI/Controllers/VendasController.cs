using Base.BUSINESS.Interfaces;
using Base.DOMAIN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeamGM.DOMAIN.Interfaces.Helpers;
using TeamGMAPI.Controllers;

namespace BaseAPI.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class VendasController : MainController
    {
        public VendasController(INotificador notificador, IUser user) 
            : base(notificador, user) { }

        [HttpGet]
        [Route("Todas")]
        public async Task<IActionResult> PegarTodasAsVendas([FromServices]IVendaBusiness vendaBusiness)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var vendas = await vendaBusiness.PegarTodasAsVendas();
                return Ok(vendas);
            }
        }

        [HttpGet]
        [Route("Pegar/{id}")]
        public async Task<IActionResult> PegarVendaPorId(int id, [FromServices] IVendaBusiness vendaBusiness)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var venda = await vendaBusiness.PegarVendaPorId(id);
                return Ok(venda);
            }
        }

        [HttpPost]
        [Route("Inserir")]
        public async Task<IActionResult> InsereVenda(Venda venda, 
            [FromServices]IVendaBusiness vendaBusiness)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var vendaSalva = await vendaBusiness.AdicionarVenda(venda);
                return Ok(vendaSalva);
            }
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public async Task<IActionResult> ExcluirVenda(int id,
            [FromServices] IVendaBusiness vendaBusiness)
        {
            var vendaExcluida = await vendaBusiness.ExcluirVenda(id);
            if (vendaExcluida == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("Excluir/{numeroPedido}")]
        public async Task<IActionResult> ExcluirVenda(string numeroPedido,
            [FromServices] IVendaBusiness vendaBusiness)
        {
            var vendaExcluida = await vendaBusiness.ExcluirVenda(numeroPedido);
            if (vendaExcluida == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("Excluir/{venda}")]
        public async Task<IActionResult> ExcluirVenda(Venda venda,
            [FromServices] IVendaBusiness vendaBusiness)
        {
            var vendaExcluida = await vendaBusiness.ExcluirVenda(venda);
            if (vendaExcluida == null)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> UpdateVenda(Venda venda,
            [FromServices] IVendaBusiness vendaBusiness)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var vendaSalva = await vendaBusiness.AtualizarVenda(venda);
                return CustomResponse(vendaSalva);
            }
        }

        [HttpPut]
        [Route("Atualizar/{id}")]
        public async Task<IActionResult> UpdateVenda(int id,
            [FromServices] IVendaBusiness vendaBusiness)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var vendaSalva = await vendaBusiness.AtualizarVenda(id);
                return CustomResponse(vendaSalva);
            }
        }
    }
}
