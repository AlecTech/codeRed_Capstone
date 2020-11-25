using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace codeRed_Capstone.Migrations.Company
{
    public partial class AddedDateFields2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HiredDate",
                table: "employee",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

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
            migrationBuilder.AlterColumn<DateTime>(
                name: "HiredDate",
                table: "employee",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

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
