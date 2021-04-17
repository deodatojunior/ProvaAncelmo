using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProvaAncelmo.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteViewModels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    sexo = table.Column<string>(nullable: true),
                    endereco = table.Column<string>(nullable: true),
                    numero = table.Column<string>(nullable: true),
                    bairro = table.Column<string>(nullable: true),
                    cep = table.Column<string>(nullable: true),
                    telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteViewModels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoViewModels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigoProduto = table.Column<string>(nullable: true),
                    preco = table.Column<double>(nullable: false),
                    categoria = table.Column<string>(nullable: true),
                    observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoViewModels", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteViewModels");

            migrationBuilder.DropTable(
                name: "ProdutoViewModels");
        }
    }
}
