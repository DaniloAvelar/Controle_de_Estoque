using Microsoft.EntityFrameworkCore.Migrations;

namespace Controle_de_Estoque.Migrations
{
    public partial class entradaCOMproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "EntradaId",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EntradaId",
                table: "Produto",
                column: "EntradaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Entradas_EntradaId",
                table: "Produto",
                column: "EntradaId",
                principalTable: "Entradas",
                principalColumn: "EntradaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Entradas_EntradaId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_EntradaId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "EntradaId",
                table: "Produto");

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
    }
}
