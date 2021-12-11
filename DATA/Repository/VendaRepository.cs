using Base.DATA.Interfaces;
using Base.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamGM.DATA.Context;

namespace Base.DATA.Repository 
{
    public class VendaRepository : IVendaRepository 
    {

        private readonly DesafioAtosContext _context;

        public VendaRepository(DesafioAtosContext context) 
        {
            _context = context;
        }

        public async Task<Venda> DeleteVendaAsync(Venda venda) {
            var vendaConsultada = await _context.Venda.FindAsync(venda.IdVenda);
            if (vendaConsultada == null)
            {
                return null;
            }
            var vendaRemovida = _context.Venda.Remove(vendaConsultada);
            await _context.SaveChangesAsync();
            return vendaRemovida.Entity;
        }

        public async Task<Venda> DeleteVendaIdAsync(int id) {
            var vendaConsultada = await _context.Venda.FindAsync(id);
            if (vendaConsultada == null)
            {
                return null;
            }
            var vendaRemovida = _context.Venda.Remove(vendaConsultada);
            await _context.SaveChangesAsync();
            return vendaRemovida.Entity;
        }

        public async Task<Venda> DeleteVendaPedidoAsync(string pedido) {
            var vendaConsultada = _context.Venda.Where(np => np.numeroPedido == pedido).FirstOrDefault();
            if (vendaConsultada == null)
            {
                return null;
            }
            var vendaRemovida = _context.Venda.Remove(vendaConsultada);
            await _context.SaveChangesAsync();
            return vendaRemovida.Entity;
        }

        public async Task<IEnumerable<Venda>> GetTodasAsVendasAsync() {
            var vendasConsultadas = _context.Venda.AsEnumerable();
            if (vendasConsultadas == null)
            {
                return null;
            }
            await _context.SaveChangesAsync();
            return vendasConsultadas.AsEnumerable();
        }

        public async Task<Venda> GetVendaIdAsync(int id) {
            var vendaConsultada = _context.Venda.FirstOrDefault(v => v.IdVenda == id);
            if (vendaConsultada == null)
            {
                return null;
            }
            else
            {
                await _context.SaveChangesAsync();
                return vendaConsultada;
            }
        }

        public async Task<Venda> GetVendaPedidoAsync(string pedido) {
            var vendaConsultada = _context.Venda.FirstOrDefault(v => v.numeroPedido == pedido);
            if (vendaConsultada == null)
            {
                return null;
            }
            else
            {
                await _context.SaveChangesAsync();
                return vendaConsultada;
            }
        }

        public async Task<Venda> InsertVendaAsync(Venda venda) {
            await _context.Venda.AddAsync(venda);
            await _context.SaveChangesAsync();
            return venda;
        }

        public async Task<Venda> UpdateVendaAsync(Venda venda) {
            var vendaAtualizada = _context.Venda.FirstOrDefault(v => v.IdVenda == venda.IdVenda);

            if (vendaAtualizada == null)
            {
                return null;
            }
            else
            {
                _context.Update(venda);
                await _context.SaveChangesAsync();
                return venda;
            }
        }

        public async Task<Venda> UpdateVendaAsync(int id)
        {
            var vendaAtualizada = _context.Venda.FirstOrDefault(v => v.IdVenda == id);

            if (vendaAtualizada == null)
            {
                return null;
            }
            else
            {
                _context.Update(vendaAtualizada);
                await _context.SaveChangesAsync();
                return vendaAtualizada;
            }
        }
    }
}
