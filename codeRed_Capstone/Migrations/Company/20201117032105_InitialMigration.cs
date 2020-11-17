using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace codeRed_Capstone.Migrations.Company
{
    public partial class InitialMigration : Migration
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
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    EmployeeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_employee_employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "ID", "Age", "City", "Department", "Email", "EmployeeID", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { -1, 30, "Edmonton", "IT", "jsmith@company.ca", null, "John", "Smith", "(780)111-2222" },
                    { -2, 31, "Edmonton", "Sales", "ajohnson@company.ca", null, "Adam", "Johnson", "(780)222-3333" },
                    { -3, 29, "Calgary", "Sales", "ksandler@company.ca", null, "Kyle", "Sandler", "(780)333-4444" },
                    { -4, 25, "Calgary", "Accounting", "jalba@company.ca", null, "Jessica", "Alba", "(403)444-5555" },
                    { -5, 30, "Banff", "CEO", "kmoss@company.ca", null, "Kate", "Moss", "(780)678-9876" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_EmployeeID",
                table: "employee",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");
        }
    }
}
