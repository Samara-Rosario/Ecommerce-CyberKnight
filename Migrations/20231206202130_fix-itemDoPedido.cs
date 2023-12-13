using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_CyberKnight.Migrations
{
    /// <inheritdoc />
    public partial class fixitemDoPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "unidadeMedidas");

            migrationBuilder.DropColumn(
                name: "itensDoPedido",
                table: "Pedidos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeNascimento",
                table: "Clientes",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "unidadeMedidas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "itensDoPedido",
                table: "Pedidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DataDeNascimento",
                table: "Clientes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
