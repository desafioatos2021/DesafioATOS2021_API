using Base.DATA.Interfaces;
using Base.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamGM.CROSSCUTTING.UnitOfWork;
using TeamGM.DATA.Context;

namespace Base.DATA.Repository 
{
    public class VendaRepository : IVendaRepository 
    {

        private readonly DesafioAtosContext _context;
        private readonly IItemVendaRepository _itemVendaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VendaRepository(DesafioAtosContext context, IItemVendaRepository itemVendaRepository, IUnitOfWork unitOfWork) 
        {
            _context = context;
            _itemVendaRepository = itemVendaRepository;
            _unitOfWork = unitOfWork;
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

            try
            {
                _unitOfWork.BeginTransaction();

                await _context.Venda.AddAsync(venda);
                await _context.SaveChangesAsync();


                venda.ItemVendas.ToList().ForEach(c => c.IdVenda = venda.IdVenda);

                await _itemVendaRepository.RegistrarItensVenda(venda.ItemVendas);
                await _context.SaveChangesAsync();

                _unitOfWork.Commit();


                return venda;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return null;
            }
        }


        
    }
}
