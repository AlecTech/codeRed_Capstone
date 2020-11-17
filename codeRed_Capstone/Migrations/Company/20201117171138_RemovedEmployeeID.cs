using Microsoft.EntityFrameworkCore.Migrations;

namespace codeRed_Capstone.Migrations.Company
{
    public partial class RemovedEmployeeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_employee_EmployeeID",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_EmployeeID",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "employee",
                type: "int(10)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_employee_EmployeeID",
                table: "employee",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_employee_EmployeeID",
                table: "employee",
                column: "EmployeeID",
                principalTable: "employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
