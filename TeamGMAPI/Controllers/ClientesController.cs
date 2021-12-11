using Base.BUSINESS.Interfaces;
using Base.DOMAIN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeamGMAPI.Controllers;

namespace BaseAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientesController : Controller
    {
        //private readonly IClienteBusiness _clienteBusiness;

        //public ClientesController(IClienteBusiness clienteBusiness)
        //{
        //    _clienteBusiness = clienteBusiness;
        //}

        [HttpPost]
        [Route("InsereCliente")]
        public async Task<IActionResult> InsereCliente(Cliente cliente,  [FromServices] IClienteBusiness clienteBusiness)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            else
            {
                var clienteSalvo = await clienteBusiness.AdicionarCliente(cliente);
                return Ok(clienteSalvo);
            }
        }
    }
}
