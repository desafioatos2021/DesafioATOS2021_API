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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DesafioAtosContext _context;

        public ProdutoRepository(DesafioAtosContext context)
        {
            _context = context;
        }

        

        public async Task<Produto> DeleteProdutoAsync(int id)
        {
            var produtoConsultado = await _context.Produto.FindAsync(id);
            if (produtoConsultado == null)
            {
                return null;
            }
            var produtoRemovido = _context.Produto.Remove(produtoConsultado);
            await _context.SaveChangesAsync();
            return produtoRemovido.Entity;
        }

        public async Task<Produto> InsertProdutoAsync(Produto produto)
        {
            await _context.Produto.AddAsync(produto);
            await _context.SaveChangesAsync();
            return produto;
        }


    }
}
