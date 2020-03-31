using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrimerProyectoAspNetCore.Migrations
{
    public partial class primeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dataUsuarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataUsuarios", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "dataUsuarios",
                columns: new[] { "id", "edad", "email", "nombre" },
                values: new object[] { 1, 21, "tiagoviezzoli@gmail.com", "Tiago" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dataUsuarios");
        }
    }
}
