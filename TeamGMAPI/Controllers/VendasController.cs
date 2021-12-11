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

        [HttpPost]
        [Route("InsereVenda")]
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
        [Route("ExcluirVenda/{id}")]
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

        [HttpPut]
        [Route("UpdateVenda")]
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
    }
}
