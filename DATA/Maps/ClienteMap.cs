using Base.DOMAIN.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.DATA.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {            
            builder.Property<int>("IdCliente")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            // TODO: Confirmar autoindentuty para Oracle
            OraclePropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("IdCliente"), 1, 1);

            builder.Property<string>("Nome")
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasKey(c => c.IdCliente);

            builder.HasMany(c => c.Vendas);
            builder.ToTable(nameof(Cliente));
        }
    }
}
