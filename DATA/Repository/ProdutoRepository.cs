using Base.DATA.Interfaces;
using Base.DOMAIN.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamGM.CROSSCUTTING.UnitOfWork;
using TeamGM.DATA.Context;

namespace Base.DATA.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DesafioAtosContext _context;
        private readonly IDapperUnitOfWork _dapperUnitOfWork;

        public ProdutoRepository(DesafioAtosContext context, IDapperUnitOfWork dapperUnitOfWork)
        {
            _context = context;
            _dapperUnitOfWork = dapperUnitOfWork;
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

        public async Task<Produto> GetProdutoIdAsyn(int id)
        {
            var produtoConsultado = _context.Produto.Where(p => p.IdProduto == id).FirstOrDefault();
            if (produtoConsultado == null) return null;
            await _context.SaveChangesAsync();
            return produtoConsultado;
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            try
            {
                _dapperUnitOfWork.BeginTransaction();

                string sqlSearch = @$"SELECT * FROM ""Produtos""";
                var produtos = SqlMapper.Query<Produto>(_dapperUnitOfWork.Session.Connection, sqlSearch);
                return produtos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Produto> InsertProdutoAsync(Produto produto)
        {
            await _context.Produto.AddAsync(produto);
            await _context.SaveChangesAsync();
            return produto;
        }


    }
}
