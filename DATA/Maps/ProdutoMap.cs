using Base.DOMAIN.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.DATA.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable(nameof(Produto))
                .HasKey(c => c.IdProduto);

            builder.Property<int>("IdProduto")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");
            
            OraclePropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("IdProduto"), 1, 1);

            builder.Property<string>("NomeProduto")
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property<float>("ValorProduto")
                .IsRequired()
                .HasColumnType("float");

            builder.Property<int>("QuantidadeEstoque")
                .IsRequired()
                .HasColumnType("integer");

            builder.Property<int>("QuantidadeVendas")
                .IsRequired()
                .HasColumnType("integer");

            builder.Property<string>("DescricaoProduto")
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property<sbyte>("Avaliacao")
                .HasColumnType("byte");

            //TODO: Leonardo confirmar
            builder.Property<byte[]>("Avaliacao")
                .HasColumnType("blob");

            //builder.HasOne(p => p.CategoriaProduto);
    }
    }
}
