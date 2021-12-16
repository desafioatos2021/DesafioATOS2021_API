using Base.BUSINESS.Interfaces;
using Base.DATA.Interfaces;
using Base.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Base.BUSINESS.Business
{
    public class ProdutoBusiness : IProdutoBusiness
    {

        private readonly IProdutoRepository _produtoRepository;
                
        public ProdutoBusiness(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Task<Produto> CadastrarProduto(Produto produto)
        {
            var produtoCadastrado = _produtoRepository.InsertProdutoAsync(produto);
            return produtoCadastrado;
        }

        public Task<Produto> ExcluirProduto(int id)
        {
            var produtoeExluido = _produtoRepository.DeleteProdutoAsync(id);
            return produtoeExluido;
        }

        public async Task<Produto> ListarProdutoId(int id)
        {
            var produtoConsultado = await _produtoRepository.GetProdutoIdAsyn(id);
            return produtoConsultado;
        }

        public async Task<IEnumerable<Produto>> ListasProdutos()
        {
            var produtos = await _produtoRepository.GetProdutosAsync();
            return produtos;
        }
    }
}
