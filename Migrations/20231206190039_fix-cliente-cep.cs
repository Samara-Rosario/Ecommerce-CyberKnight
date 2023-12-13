using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_CyberKnight.Migrations
{
    /// <inheritdoc />
    public partial class fixclientecep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Clientes");
        }
    }
}
