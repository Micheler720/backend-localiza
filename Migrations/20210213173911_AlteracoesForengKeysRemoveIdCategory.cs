using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AlteracoesForengKeysRemoveIdCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_car_categories_CategoryId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_CategoryId",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "appointments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_appointments_CategoryId",
                table: "appointments",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_car_categories_CategoryId",
                table: "appointments",
                column: "CategoryId",
                principalTable: "car_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
