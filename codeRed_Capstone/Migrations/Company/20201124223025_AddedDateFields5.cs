using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace codeRed_Capstone.Migrations.Company
{
    public partial class AddedDateFields5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HiredDate",
                table: "employee",
                type: "date",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -5,
                columns: new[] { "Email", "HiredDate" },
                values: new object[] { "kmoss@company.ca", new DateTime(2020, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -4,
                columns: new[] { "Email", "HiredDate" },
                values: new object[] { "jalba@company.ca", new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -3,
                columns: new[] { "Email", "HiredDate" },
                values: new object[] { "ksandler@company.ca", new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -2,
                columns: new[] { "Email", "HiredDate" },
                values: new object[] { "ajohnson@company.ca", new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "employee",
                keyColumn: "ID",
                keyValue: -1,
                columns: new[] { "Email", "HiredDate" },
                values: new object[] { "jsmith@company.ca", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
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
                oldDefaultValueSql: "NOW()");

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
