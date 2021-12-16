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

        [HttpGet]
        [Route("ListarProdutos")]
        public async Task<IActionResult> ConsultarProduto([FromServices] IProdutoBusiness produtoBusiness)
        {
            var produtos = await produtoBusiness.ListasProdutos();
            return Ok(produtos);
        }

        [HttpPut]
        [Route("UpdateProduto")]
        public async Task<IActionResult> UpdateProduto(Produto produto, 
            [FromServices] IProdutoBusiness produtoBusiness)
        {
            try
            {
                var produtoAtualizado = await produtoBusiness.AtualizarProduto(produto);
                return CustomResponse(produtoAtualizado);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

            // FIXME: Qual das duas implementacoes e correta de se usar? A de cima ou essa?
            //if (!ModelState.IsValid)
            //    return BadRequest();
            //else
            //{
            //    var produtoAtualizado = await produtoBusiness.AtualizarProduto(produto);
            //    return CustomResponse(ModelState);
            //}
        }
    }
}
