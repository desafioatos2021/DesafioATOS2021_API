using Base.BUSINESS.Interfaces;
using Base.DOMAIN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeamGMAPI.Controllers;

namespace BaseAPI.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class VendasController : Controller
    {
        [HttpPost]
        [Route("InsereVenda")]
        public async Task<IActionResult> InsereVenda(Venda venda, [FromServices]IVendaBusiness vendaBusiness)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var vendaSalva = await vendaBusiness.AdicionarVenda(venda);
                return Ok(vendaSalva);
            }
        }
    }
}
