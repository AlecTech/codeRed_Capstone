using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace codeRed_Capstone.Migrations.Company
{
    public partial class TwoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(60)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    LastName = table.Column<string>(type: "varchar(60)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false, defaultValue: "info@company.ca")
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    Phone = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    Age = table.Column<int>(type: "int(1)", nullable: false),
                    City = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    Department = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "employeedate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HiredDate = table.Column<DateTime>(type: "date", nullable: false),
                    FiredDate = table.Column<DateTime>(type: "date", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "NOW()"),
                    EmployeeID = table.Column<int>(type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeedate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeDate_Employee",
                        column: x => x.EmployeeID,
                        principalTable: "employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "ID", "Age", "City", "Department", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { -1, 30, "Edmonton", "IT", "jsmith@company.ca", "John", "Smith", "(780)111-2222" },
                    { -2, 31, "Edmonton", "Sales", "ajohnson@company.ca", "Adam", "Johnson", "(780)222-3333" },
                    { -3, 29, "Calgary", "Sales", "ksandler@company.ca", "Kyle", "Sandler", "(780)333-4444" },
                    { -4, 25, "Calgary", "Accounting", "jalba@company.ca", "Jessica", "Alba", "(403)444-5555" },
                    { -5, 30, "Banff", "CEO", "kmoss@company.ca", "Kate", "Moss", "(780)678-9876" }
                });

            migrationBuilder.InsertData(
                table: "employeedate",
                columns: new[] { "ID", "EmployeeID", "FiredDate", "HiredDate" },
                values: new object[,]
                {
                    { -1, -1, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -2, -2, new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -3, -3, null, new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -4, -4, null, new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -5, -5, null, new DateTime(2020, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "FK_EmployeeDate_Employee",
                table: "employeedate",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeedate");

            migrationBuilder.DropTable(
                name: "employee");
        }
    }
}
