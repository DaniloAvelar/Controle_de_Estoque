using Microsoft.EntityFrameworkCore.Migrations;

namespace Controle_de_Estoque.Migrations
{
    public partial class IDEntradaTProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Entradas_EntradaId",
                table: "Produto");

            migrationBuilder.AlterColumn<int>(
                name: "EntradaId",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "Entradas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_IdProduto",
                table: "Entradas",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Produto_IdProduto",
                table: "Entradas",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Entradas_EntradaId",
                table: "Produto",
                column: "EntradaId",
                principalTable: "Entradas",
                principalColumn: "EntradaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Produto_IdProduto",
                table: "Entradas");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Entradas_EntradaId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Entradas_IdProduto",
                table: "Entradas");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "Entradas");

            migrationBuilder.AlterColumn<int>(
                name: "EntradaId",
                table: "Produto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Entradas_EntradaId",
                table: "Produto",
                column: "EntradaId",
                principalTable: "Entradas",
                principalColumn: "EntradaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
