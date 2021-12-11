using Base.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DATA.Interfaces {
    public interface IVendaRepository 
    {
        Task<Venda> InsertVendaAsync(Venda venda);
        Task<IEnumerable<Venda>> GetTodasAsVendasAsync();
        Task<Venda> GetVendaIdAsync(int id);
        Task<Venda> GetVendaPedidoAsync(string pedido);
        Task<Venda> UpdateVendaAsync(Venda venda);
        Task<Venda> UpdateVendaAsync(int id);
        Task<Venda> DeleteVendaAsync(Venda venda);
        Task<Venda> DeleteVendaIdAsync(int id);
        Task<Venda> DeleteVendaPedidoAsync(string pedido);
    }
}
