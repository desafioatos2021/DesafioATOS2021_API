using Base.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DATA.Interfaces
{
    public interface IProdutoRepository
    {
        Produto CadastrarProduto(Produto produto);
        Task<Produto> DeleteProdutoAsync(int id);
        Task<Produto> InsertProdutoAsync(Produto produto);
        Task<Produto> GetProdutoIdAsyn(int id);
        Task<IEnumerable<Produto>> GetProdutosAsync();
        Task<Produto> UpdateProdutoAsync(Produto produto);
    }
}
