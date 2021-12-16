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
        
        Task<Produto> DeleteProdutoAsync(int id);
        Task<Produto> InsertProdutoAsync(Produto produto);
    }
}
