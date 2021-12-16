using Base.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.BUSINESS.Interfaces
{
    public interface IProdutoBusiness
    {
        Task<Produto> ExcluirProduto(int id);
        Task<Produto> CadastrarProduto(Produto produto);
        Task<Produto> ListarProdutoId(int id);
        Task<IEnumerable<Produto>> ListasProdutos();
    }
}
