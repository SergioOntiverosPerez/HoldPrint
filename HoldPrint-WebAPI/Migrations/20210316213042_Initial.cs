using Microsoft.EntityFrameworkCore.Migrations;

namespace HoldPrint_WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Cpf", "Name", "Surname" },
                values: new object[] { 1, "111.222.333-45", "nome1", "sobrenome1" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Cpf", "Name", "Surname" },
                values: new object[] { 2, "999.888.777-45", "nome2", "sobrenome2" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Cpf", "Name", "Surname" },
                values: new object[] { 3, "652.563.452-87", "nome3", "sobrenome3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
