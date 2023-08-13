using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_Management.Migrations
{
    /// <inheritdoc />
    public partial class ID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ID",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID",
                table: "Employees");
        }
    }
}
