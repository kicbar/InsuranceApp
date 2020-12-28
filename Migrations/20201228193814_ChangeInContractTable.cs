using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceApp.Migrations
{
    public partial class ChangeInContractTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContractNr",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractNr",
                table: "Contracts");
        }
    }
}
