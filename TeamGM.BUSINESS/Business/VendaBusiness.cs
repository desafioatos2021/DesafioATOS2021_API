using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.BUSINESS.Interfaces;
using Base.DATA.Interfaces;
using Base.DOMAIN.Models;

namespace Base.BUSINESS.Business 
{
    public class VendaBusiness : IVendaBusiness 
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaBusiness(IVendaRepository vendaRepository) 
        {
            _vendaRepository = vendaRepository;
        }

        public Task<Venda> AdicionarVenda(Venda venda) 
        {
            var vendaRetorno = _vendaRepository.InsertVendaAsync(venda);
            return vendaRetorno;
        }

        public async Task<Venda> AtualizarVenda(Venda venda) =>
            await _vendaRepository.UpdateVendaAsync(venda);

        public Task<Venda> ExcluirVenda(int id)
        {
            var vendaExcluida = _vendaRepository.DeleteVendaIdAsync(id);
            return vendaExcluida;
        }


        public Task<Venda> ExcluirVenda(string numeroPedido) =>
            _vendaRepository.DeleteVendaPedidoAsync(numeroPedido);

        public Task<IEnumerable<Venda>> PegarTodasAsVendas()
        {
            var vendas = _vendaRepository.GetTodasAsVendasAsync();
            return vendas;
        }

        public Task<Venda> PegarVendaPorId(int id)
        {
            var venda = _vendaRepository.GetVendaIdAsync(id);
            return venda;
        }
    }
}
