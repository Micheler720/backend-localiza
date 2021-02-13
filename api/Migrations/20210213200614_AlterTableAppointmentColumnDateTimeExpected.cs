using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AlterTableAppointmentColumnDateTimeExpected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeExpectedCollection",
                table: "appointments",
                newName: "DateTimeExpectedCollected");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeExpectedCollected",
                table: "appointments",
                newName: "DateTimeExpectedCollection");
        }
    }
}
