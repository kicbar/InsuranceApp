using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceApp.Migrations
{
    public partial class CorectPersonsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Perosns",
                table: "Perosns");

            migrationBuilder.RenameTable(
                name: "Perosns",
                newName: "Persons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Perosns");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Perosns",
                table: "Perosns",
                column: "Id");
        }
    }
}
