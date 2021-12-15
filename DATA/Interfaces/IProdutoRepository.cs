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
    }
}
