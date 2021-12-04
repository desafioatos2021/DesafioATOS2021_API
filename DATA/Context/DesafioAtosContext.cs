using Base.DATA.Maps;
using Base.DOMAIN.Models;
using Microsoft.EntityFrameworkCore;



namespace TeamGM.DATA.Context
{
    public class DesafioAtosContext : DbContext
    {
        public DesafioAtosContext(DbContextOptions<DesafioAtosContext> options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Venda> Venda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new VendaProdutoMap());
            

        }


    }
}
