using Base.DOMAIN.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.DATA.Maps
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable(nameof(Venda))
                .HasKey(c => c.IdVenda);

            builder.HasMany(c => c.ItemVendas);

            builder.HasOne(c => c.Cliente).WithMany(c => c.Vendas).IsRequired().HasForeignKey(c => c.IdCliente);
        }
    }
}
