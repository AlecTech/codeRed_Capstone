using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace codeRed_Capstone.Migrations.Company
{
    public partial class AddedDateFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "employee",
                type: "varchar(100)",
                nullable: true,
                defaultValue: "info@company.ca",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldDefaultValue: "info@company.ca")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "FiredDate",
                table: "employee",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HiredDate",
                table: "employee",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "employee",
                type: "datetime",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP()");

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
                columns: new[] { "Email", "FiredDate", "HiredDate" },
                values: new object[] { "ajohnson@company.ca", new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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
                name: "FiredDate",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "HiredDate",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "employee");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "employee",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "info@company.ca",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true,
                oldDefaultValue: "info@company.ca")
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("MySql:Collation", "utf8mb4_general_ci")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:Collation", "utf8mb4_general_ci");

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
