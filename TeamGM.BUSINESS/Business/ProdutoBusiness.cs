using Base.BUSINESS.Interfaces;
using Base.DATA.Interfaces;
using Base.DOMAIN.Models;
using System;
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
    }
}
