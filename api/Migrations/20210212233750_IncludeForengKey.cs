using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class IncludeForengKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdFuel",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdModel",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_cars_IdCategory",
                table: "cars",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_cars_IdFuel",
                table: "cars",
                column: "IdFuel");

            migrationBuilder.CreateIndex(
                name: "IX_cars_IdModel",
                table: "cars",
                column: "IdModel");

            migrationBuilder.AddForeignKey(
                name: "FK_cars_car_categories_IdCategory",
                table: "cars",
                column: "IdCategory",
                principalTable: "car_categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cars_car_fuels_IdFuel",
                table: "cars",
                column: "IdFuel",
                principalTable: "car_fuels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cars_car_models_IdModel",
                table: "cars",
                column: "IdModel",
                principalTable: "car_models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_car_categories_IdCategory",
                table: "cars");

            migrationBuilder.DropForeignKey(
                name: "FK_cars_car_fuels_IdFuel",
                table: "cars");

            migrationBuilder.DropForeignKey(
                name: "FK_cars_car_models_IdModel",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_IdCategory",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_IdFuel",
                table: "cars");

            migrationBuilder.DropIndex(
                name: "IX_cars_IdModel",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "IdFuel",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "IdModel",
                table: "cars");
        }
    }
}
