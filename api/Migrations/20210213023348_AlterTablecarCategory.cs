using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AlterTablecarCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "car_categories",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "car_categories",
                newName: "Category");
        }
    }
}
