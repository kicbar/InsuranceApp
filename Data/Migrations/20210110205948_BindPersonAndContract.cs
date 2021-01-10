using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceApp.Migrations
{
    public partial class BindPersonAndContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InsuredPerson",
                table: "Contracts",
                newName: "Value");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Contracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Contracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InsuredId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_InsuredId",
                table: "Contracts",
                column: "InsuredId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Persons_InsuredId",
                table: "Contracts",
                column: "InsuredId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Persons_InsuredId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_InsuredId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "InsuredId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Contracts",
                newName: "InsuredPerson");
        }
    }
}
