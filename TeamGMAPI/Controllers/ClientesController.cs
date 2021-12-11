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
    public class ClientesController : MainController
    {
       
        public ClientesController(INotificador notificador, IUser user) : base(notificador, user)
        {

        }


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


        [HttpPost]
        [Route("UpdateCliente")]
        public async Task<IActionResult> UpdateCliente(Cliente cliente, [FromServices] IClienteBusiness clienteBusiness)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var clienteSalvo = await clienteBusiness.UpdateCliente(cliente);
                return CustomResponse(ModelState);
            }
        }

    }
}
