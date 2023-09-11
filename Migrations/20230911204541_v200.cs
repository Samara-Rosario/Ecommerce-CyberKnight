using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_CyberKnight.Migrations
{
    /// <inheritdoc />
    public partial class v200 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdEndereco",
                table: "Pedidos",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdEndereco",
                table: "Clientes",
                column: "IdEndereco");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecoes_IdEndereco",
                table: "Clientes",
                column: "IdEndereco",
                principalTable: "Enderecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Enderecoes_IdEndereco",
                table: "Pedidos",
                column: "IdEndereco",
                principalTable: "Enderecoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecoes_IdEndereco",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Enderecoes_IdEndereco",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdEndereco",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdEndereco",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Pedidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
