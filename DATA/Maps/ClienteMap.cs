using Base.DOMAIN.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.DATA.Maps
{
   public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(nameof(Cliente));

            // TODO: Ver implementação com Oracle
            builder.Property<int>("IdCliente")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");
                //.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property<string>("Nome")
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasKey(c => c.IdCliente);

            builder.HasMany(c => c.Vendas);
        }
    }
}
