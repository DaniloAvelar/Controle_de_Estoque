using Microsoft.EntityFrameworkCore.Migrations;

namespace Controle_de_Estoque.Migrations
{
    public partial class ProdutoEntrada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoIdProduto",
                table: "Entradas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_ProdutoIdProduto",
                table: "Entradas",
                column: "ProdutoIdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Produto_ProdutoIdProduto",
                table: "Entradas",
                column: "ProdutoIdProduto",
                principalTable: "Produto",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Produto_ProdutoIdProduto",
                table: "Entradas");

            migrationBuilder.DropIndex(
                name: "IX_Entradas_ProdutoIdProduto",
                table: "Entradas");

            migrationBuilder.DropColumn(
                name: "ProdutoIdProduto",
                table: "Entradas");
        }
    }
}
