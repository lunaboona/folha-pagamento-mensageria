using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBApi.Migrations
{
    /// <inheritdoc />
    public partial class TesteMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folhas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mes = table.Column<int>(type: "INTEGER", nullable: true),
                    Ano = table.Column<int>(type: "INTEGER", nullable: true),
                    Horas = table.Column<int>(type: "INTEGER", nullable: true),
                    Valor = table.Column<double>(type: "REAL", nullable: true),
                    Bruto = table.Column<double>(type: "REAL", nullable: true),
                    Irrf = table.Column<double>(type: "REAL", nullable: true),
                    Inss = table.Column<double>(type: "REAL", nullable: true),
                    Fgts = table.Column<double>(type: "REAL", nullable: true),
                    Liquido = table.Column<double>(type: "REAL", nullable: true),
                    Funcionario = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folhas");
        }
    }
}
