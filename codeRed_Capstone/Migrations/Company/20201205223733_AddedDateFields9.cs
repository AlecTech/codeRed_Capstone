using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace codeRed_Capstone.Migrations.Company
{
    public partial class AddedDateFields9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimesModified",
                table: "employee",
                type: "int(1)",
                nullable: false,
                defaultValue: 1);

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
            migrationBuilder.DropColumn(
                name: "TimesModified",
                table: "employee");

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
    }
}
