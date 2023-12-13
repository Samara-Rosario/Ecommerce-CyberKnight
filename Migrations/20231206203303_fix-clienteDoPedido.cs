using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_CyberKnight.Migrations
{
    /// <inheritdoc />
    public partial class fixclienteDoPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_IdClientes",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdClientes",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "IdClientes",
                table: "Pedidos");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdCliente",
                table: "Pedidos",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_IdCliente",
                table: "Pedidos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_IdCliente",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdCliente",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "IdClientes",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdClientes",
                table: "Pedidos",
                column: "IdClientes");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_IdClientes",
                table: "Pedidos",
                column: "IdClientes",
                principalTable: "Clientes",
                principalColumn: "Id");
        }
    }
}
