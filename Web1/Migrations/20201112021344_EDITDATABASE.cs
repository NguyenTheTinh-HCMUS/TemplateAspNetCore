using Microsoft.EntityFrameworkCore.Migrations;

namespace Web1.Migrations
{
    public partial class EDITDATABASE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_GetDepartments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetDepartments",
                table: "GetDepartments");

            migrationBuilder.RenameTable(
                name: "GetDepartments",
                newName: "Departments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "GetDepartments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetDepartments",
                table: "GetDepartments",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_GetDepartments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "GetDepartments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
