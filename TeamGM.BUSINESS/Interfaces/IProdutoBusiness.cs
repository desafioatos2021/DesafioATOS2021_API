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

    }
}
