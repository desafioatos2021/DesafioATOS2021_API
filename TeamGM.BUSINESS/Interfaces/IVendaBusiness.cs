using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.DOMAIN.Models;

namespace Base.BUSINESS.Interfaces 
{
    public interface IVendaBusiness 
    {
        Task<Venda> AdicionarVenda(Venda venda);
    }
}
