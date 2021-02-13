using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "car_brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "car_categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "car_fuels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_fuels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "car_models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CleanCar = table.Column<bool>(type: "bit", nullable: false),
                    FullTank = table.Column<bool>(type: "bit", nullable: false),
                    TankLightsPendant = table.Column<bool>(type: "bit", nullable: false),
                    Crumpled = table.Column<bool>(type: "bit", nullable: false),
                    Scratches = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Birthay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "operators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    Registration = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Board = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    HourPrice = table.Column<double>(type: "float", nullable: false),
                    LuggageCapacity = table.Column<int>(type: "int", nullable: false),
                    TankCapacity = table.Column<int>(type: "int", nullable: false),
                    IdBrand = table.Column<int>(type: "int", nullable: false),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    IdFuel = table.Column<int>(type: "int", nullable: false),
                    IdModel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cars_car_brands_IdBrand",
                        column: x => x.IdBrand,
                        principalTable: "car_brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cars_car_categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "car_categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cars_car_fuels_IdFuel",
                        column: x => x.IdFuel,
                        principalTable: "car_fuels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cars_car_models_IdModel",
                        column: x => x.IdModel,
                        principalTable: "car_models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Schedule = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeExpectedCollection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeCollected = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeExpectedDelivery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeDelivery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HourPrice = table.Column<double>(type: "float", nullable: false),
                    HourLocation = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<double>(type: "float", nullable: false),
                    AdditionalCosts = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Inspected = table.Column<bool>(type: "bit", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    IdOperator = table.Column<int>(type: "int", nullable: false),
                    OperatorId = table.Column<int>(type: "int", nullable: true),
                    IdCheckList = table.Column<int>(type: "int", nullable: false),
                    CheckListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appointments_car_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "car_categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appointments_cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_CheckLists_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "CheckLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appointments_CheckLists_IdCheckList",
                        column: x => x.IdCheckList,
                        principalTable: "CheckLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appointments_clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_operators_IdOperator",
                        column: x => x.IdOperator,
                        principalTable: "operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appointments_operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_CategoryId",
                table: "appointments",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_CheckListId",
                table: "appointments",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_ClientId",
                table: "appointments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_IdCar",
                table: "appointments",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_IdCheckList",
                table: "appointments",
                column: "IdCheckList");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_IdClient",
                table: "appointments",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_IdOperator",
                table: "appointments",
                column: "IdOperator");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_OperatorId",
                table: "appointments",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_cars_IdBrand",
                table: "cars",
                column: "IdBrand");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "CheckLists");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "operators");

            migrationBuilder.DropTable(
                name: "car_brands");

            migrationBuilder.DropTable(
                name: "car_categories");

            migrationBuilder.DropTable(
                name: "car_fuels");

            migrationBuilder.DropTable(
                name: "car_models");
        }
    }
}
