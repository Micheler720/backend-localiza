using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AlteracoesForengKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_CheckLists_CheckListId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_clients_ClientId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_operators_OperatorId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_CheckListId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_ClientId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_IdCheckList",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_OperatorId",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "CheckListId",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "appointments");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_IdCheckList",
                table: "appointments",
                column: "IdCheckList",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_appointments_IdCheckList",
                table: "appointments");

            migrationBuilder.AddColumn<int>(
                name: "CheckListId",
                table: "appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_appointments_CheckListId",
                table: "appointments",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_ClientId",
                table: "appointments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_IdCheckList",
                table: "appointments",
                column: "IdCheckList");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_OperatorId",
                table: "appointments",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_CheckLists_CheckListId",
                table: "appointments",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_clients_ClientId",
                table: "appointments",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_operators_OperatorId",
                table: "appointments",
                column: "OperatorId",
                principalTable: "operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
