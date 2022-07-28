using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Birthday",
                table: "Employees");

            migrationBuilder.AddCheckConstraint(
                name: "Birthday",
                table: "Employees",
                sql: "DATEDIFF(year, Birthday, CONVERT(date, GETDATE())) >= 18");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Birthday",
                table: "Employees");

            migrationBuilder.AddCheckConstraint(
                name: "Birthday",
                table: "Employees",
                sql: "DATEDIFF(year, GETDATE(), Birthday) >= 18");
        }
    }
}
