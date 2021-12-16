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
    public class ProdutosController : MainController
    {
        private readonly IProdutoBusiness _produtoBusiness;

        public ProdutosController(INotificador notificador, IUser user, IProdutoBusiness produtoBusiness) : base(notificador, user)
        {
            _produtoBusiness = produtoBusiness;
        }

        [HttpDelete]
        [Route("ExcluirProduto/{id}")]
        public async Task<IActionResult> ExcluirProduto(int id)
        {
            var clienteExcluido = await _produtoBusiness.ExcluirProduto(id);
            if (clienteExcluido == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        [Route("CadastroProduto")]
        public async Task<IActionResult> CadastroProduto(Produto produto,
            [FromServices] IProdutoBusiness produtoBusiness)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var produtoCadastrado = await produtoBusiness.CadastrarProduto(produto);
                return Ok(produto);
            }
        }

        [HttpGet]
        [Route("ListarProdutoId/{id}")]
        public async Task<IActionResult> ConsultarProduto(int id,
            [FromServices] IProdutoBusiness produtoBusiness)
        {
            var produto = await produtoBusiness.ListarProdutoId(id);
            return Ok(produto);
        }
    }
}
