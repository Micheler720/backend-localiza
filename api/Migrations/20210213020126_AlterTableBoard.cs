using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AlterTableBoard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Placa",
                table: "cars",
                newName: "Board");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Board",
                table: "cars",
                newName: "Placa");
        }
    }
}
