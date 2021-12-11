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
        Task<Venda> ExcluirVenda(int id);
        Task<Venda> ExcluirVenda(Venda venda);
        Task<Venda> ExcluirVenda(string numeroPedido);
        Task<Venda> AtualizarVenda(Venda venda);
        Task<Venda> AtualizarVenda(int id);
        Task<IEnumerable<Venda>> PegarTodasAsVendas();
        Task<Venda> PegarVendaPorId(int id);
    }
}
