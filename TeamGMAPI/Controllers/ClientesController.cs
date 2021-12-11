﻿using Base.BUSINESS.Interfaces;
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
        /// Exclui um cliente.
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
