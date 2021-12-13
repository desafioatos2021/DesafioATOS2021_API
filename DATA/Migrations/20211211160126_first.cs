using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.DATA.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IdEndereco = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ValorProduto = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    QuantidadeVendas = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DescricaoProduto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IdFabricante = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Avaliacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FotoProduto = table.Column<byte[]>(type: "RAW(2000)", nullable: true),
                    CategoriaProduto = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.IdProduto);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    IdVenda = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.IdVenda);
                    table.ForeignKey(
                        name: "FK_Venda_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemVenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "1, 1"),
                    IdVenda = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdProduto = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Quantidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProdutoIdProduto = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    VendaIdVenda = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Produto_ProdutoIdProduto",
                        column: x => x.ProdutoIdProduto,
                        principalTable: "Produto",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Venda_VendaIdVenda",
                        column: x => x.VendaIdVenda,
                        principalTable: "Venda",
                        principalColumn: "IdVenda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_ProdutoIdProduto",
                table: "ItemVenda",
                column: "ProdutoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_VendaIdVenda",
                table: "ItemVenda",
                column: "VendaIdVenda");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_IdCliente",
                table: "Venda",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemVenda");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
