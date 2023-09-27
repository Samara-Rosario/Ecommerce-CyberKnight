using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_CyberKnight.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_IdEndereco",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "categoria",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "unidadeMedida",
                table: "Produtos");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "Produtos",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produtos",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUnidadeMedida",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdClientes",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rua",
                table: "Enderecoes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "Enderecoes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Enderecoes",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Enderecoes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Enderecoes",
                type: "varchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Enderecoes",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProduto = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "unidadeMedidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProduto = table.Column<int>(type: "int", nullable: true),
                    Sigla = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeExtenso = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidadeMedidas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdUnidadeMedida",
                table: "Produtos",
                column: "IdUnidadeMedida");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_IdCategoria",
                table: "Produtos",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_unidadeMedidas_IdUnidadeMedida",
                table: "Produtos",
                column: "IdUnidadeMedida",
                principalTable: "unidadeMedidas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_IdClientes",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_IdCategoria",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_unidadeMedidas_IdUnidadeMedida",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "unidadeMedidas");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_IdUnidadeMedida",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdClientes",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IdUnidadeMedida",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IdClientes",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "Produtos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produtos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "categoria",
                table: "Produtos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "unidadeMedida",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Rua",
                table: "Enderecoes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "Enderecoes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Enderecoes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Enderecoes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Enderecoes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldMaxLength: 8)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Enderecoes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_IdEndereco",
                table: "Pedidos",
                column: "IdEndereco",
                principalTable: "Clientes",
                principalColumn: "Id");
        }
    }
}
