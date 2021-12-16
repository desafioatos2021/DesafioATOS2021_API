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

        /// <summary>
        /// Exclui um produto pelo seu ID
        /// </summary>
        /// <param name="id" example="64">ID do Produto</param>
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

        /// <summary>
        /// Cadastra um produto com todos os seus valores preenchidos ou somente os obrigatórios.
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="produtoBusiness"></param>
        [HttpPost]
        [Route("CadastroProduto")]
        public async Task<IActionResult> CadastroProduto(Produto produto,
            [FromServices] IProdutoBusiness produtoBusiness)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }
            else
            {
                var produtoCadastrado = await produtoBusiness.CadastrarProduto(produto);
                return Ok(produtoCadastrado);
            }
        }

        /// <summary>
        /// Lista um único produto a partir de seu ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="produtoBusiness"></param>
        [HttpGet]
        [Route("ListarProdutoId/{id}")]
        public async Task<IActionResult> ConsultarProduto(int id,
            [FromServices] IProdutoBusiness produtoBusiness)
        {
            var produto = await produtoBusiness.ListarProdutoId(id);
            return Ok(produto);
        }

        /// <summary>
        /// Lista todos os produtos cadastrados atualmente.
        /// </summary>
        /// <param name="produtoBusiness"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ListarProdutos")]
        public async Task<IActionResult> ConsultarProduto([FromServices] IProdutoBusiness produtoBusiness)
        {
            var produtos = await produtoBusiness.ListasProdutos();
            return Ok(produtos);
        }

        /// <summary>
        /// Atualiza um produto e todos os seus campos de valor a partir do ID desse produto.
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="produtoBusiness"></param>
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
        }
    }
}
