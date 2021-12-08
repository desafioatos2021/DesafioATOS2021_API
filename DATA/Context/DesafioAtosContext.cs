using Base.DATA.Maps;
using Base.DOMAIN.Models;
using Microsoft.EntityFrameworkCore;



namespace TeamGM.DATA.Context
{
    public class DesafioAtosContext : DbContext
    {
        public DesafioAtosContext(DbContextOptions<DesafioAtosContext> options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new ItemVendaMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            

        }


    }
}
