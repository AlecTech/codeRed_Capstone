using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace codeRed_Capstone.Migrations.Company
{
    public partial class AddedDateFields3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ValidationValidFrom",
                table: "employee",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -5,
                column: "Email",
                value: "kmoss@company.ca");

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -4,
                column: "Email",
                value: "jalba@company.ca");

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -3,
                column: "Email",
                value: "ksandler@company.ca");

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -2,
                column: "Email",
                value: "ajohnson@company.ca");

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -1,
                column: "Email",
                value: "jsmith@company.ca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidationValidFrom",
                table: "employee");

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -5,
                column: "Email",
                value: "kmoss@company.ca");

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -4,
                column: "Email",
                value: "jalba@company.ca");

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -3,
                column: "Email",
                value: "ksandler@company.ca");

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -2,
                column: "Email",
                value: "ajohnson@company.ca");

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -1,
                column: "Email",
                value: "jsmith@company.ca");
        }
    }
}
