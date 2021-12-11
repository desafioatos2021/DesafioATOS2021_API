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

        public Task<Venda> DeleteVendaAsync(Venda venda) {
            throw new NotImplementedException();
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

        public Task<Venda> DeleteVendaPedidoAsync(string pedido) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Venda>> GetTodasAsVendasAsync() {
            throw new NotImplementedException();
        }

        public Task<Venda> GetVendaIdAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<Venda> GetVendaPedidoAsync(string pedido) {
            throw new NotImplementedException();
        }

        public async Task<Venda> InsertVendaAsync(Venda venda) {
            await _context.Venda.AddAsync(venda);
            await _context.SaveChangesAsync();
            return venda;
        }

        public Task<Venda> UpdateVendaAsync(Venda venda) {
            throw new NotImplementedException();
        }
    }
}
