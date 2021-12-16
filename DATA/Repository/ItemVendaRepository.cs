using Base.DATA.Interfaces;
using Base.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamGM.DATA.Context;

namespace Base.DATA.Repository
{
    public class ItemVendaRepository : IItemVendaRepository
    {
        private readonly DesafioAtosContext _context;

        public ItemVendaRepository(DesafioAtosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemVenda>> AtualizarItensVenda(IEnumerable<ItemVenda> produtos)
        {
            var listProdutos = _context.ItemVenda.Where(c => c.IdVenda == produtos.FirstOrDefault().IdVenda).ToList();

            await AtualizaItemVenda(listProdutos, produtos);

            return listProdutos;
        }

        public async Task<IEnumerable<ItemVenda>> ExcluirItensVenda(IEnumerable<ItemVenda> produtos)
        {
            var listProdutos = _context.ItemVenda.Where(c => c.IdVenda == produtos.FirstOrDefault().IdVenda).ToList();
            _context.ItemVenda.RemoveRange(listProdutos);
            await _context.SaveChangesAsync();
            return listProdutos;
        }

        public async Task ItensParaRemover(int id)
        {
            var itensRemovidos = _context.ItemVenda.Where(c => c.Id == id && c.IdVenda == 0).ToList();
            _context.ItemVenda.RemoveRange(itensRemovidos);
            await _context.SaveChangesAsync();

        }
        

        public async Task<IEnumerable<ItemVenda>> RegistrarItensVenda(IEnumerable<ItemVenda> produtos)
        {
            await _context.ItemVenda.AddRangeAsync(produtos);
            await _context.SaveChangesAsync();
            return produtos;

        }


        private async Task AtualizaItemVenda(IEnumerable<ItemVenda> itensAntigos, IEnumerable<ItemVenda> itensNovos)
        {
            var antigos = itensAntigos.OrderBy(c => c.IdProduto).ToArray();
            var novos = itensAntigos.OrderBy(c => c.IdProduto).ToArray();

            for (int i = 0; i < itensAntigos.Count(); i++)
            {
                antigos[i].IdProduto = novos[i].IdProduto;
                antigos[i].Quantidade = novos[i].Quantidade;
            }

            _context.ItemVenda.UpdateRange(antigos.ToList());
            await _context.SaveChangesAsync();


        }
    }
}
