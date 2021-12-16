using Base.BUSINESS.Interfaces;
using Base.DOMAIN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TeamGM.DOMAIN.Interfaces.Helpers;
using TeamGMAPI.Controllers;

namespace BaseAPI.Controllers
{

    
    public class ClientesController : MainController
    {
        private readonly IClienteBusiness _clienteBusiness;

        public ClientesController(INotificador notificador, IUser user, IClienteBusiness clienteBusiness) : base(notificador, user)
        {
            _clienteBusiness = clienteBusiness;
        }

        /// <summary>
        /// Insere um cliente no sistema com todos os seus valores preenchidos ou só os obrigatórios
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="clienteBusiness"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Exclui um cliente a partir de seu ID.
        /// </summary>
        /// <param name="id" example="123">Id do cliente</param>
        [HttpDelete]
        [Route("ExcluirCliente/{id}")]
        public async Task<IActionResult> ExcluiCliente(int id)
        {
            var clienteExcluido = await _clienteBusiness.ExcluirCliente(id);
            if (clienteExcluido == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Atualiza um cliente a partir de seu ID.
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="clienteBusiness"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateCliente")]
        public async Task<IActionResult> UpdateCliente(Cliente cliente, [FromServices] IClienteBusiness clienteBusiness)
        {
            try
            {
                var clienteAtualizado = await clienteBusiness.UpdateCliente(cliente);
                return CustomResponse(clienteAtualizado);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Lista todos os clientes cadastrados até o momento no sistema.
        /// </summary>
        /// <param name="clienteBusiness"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetClientes")]
        public async Task<IActionResult> GetClientes([FromServices] IClienteBusiness clienteBusiness)
        {
            var clientes = await clienteBusiness.ListarClientes();
            return Ok(clientes);
        }

        /// <summary>
        /// Consulta um cliente pelo seu nome.
        /// </summary>
        /// <param name="nome" example="Nome"></param>
        /// <param name="clienteBusiness"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetClienteNome/{nome}")]
        public async Task<IActionResult> GetClientePorNome(string nome
            , [FromServices] IClienteBusiness clienteBusiness)
        {
            var cliente = await clienteBusiness.ConsultarClientePorNome(nome);
            return Ok(cliente);
        }

        /// <summary>
        /// Consulta um cliente pelo seu ID.
        /// </summary>
        /// <param name="id" example="3"></param>
        /// <param name="clienteBusiness"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetClienteId/{id}")]
        public async Task<IActionResult> GetClientePorId(int id
            , [FromServices] IClienteBusiness clienteBusiness)
        {
            var cliente = await clienteBusiness.ConsultarClientePorId(id);
            return Ok(cliente);
        }
    }
}
