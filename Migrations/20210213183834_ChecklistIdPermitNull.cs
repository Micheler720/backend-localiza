using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class ChecklistIdPermitNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_CheckLists_IdCheckList",
                table: "appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckLists",
                table: "CheckLists");

            migrationBuilder.DropIndex(
                name: "IX_appointments_IdCheckList",
                table: "appointments");

            migrationBuilder.RenameTable(
                name: "CheckLists",
                newName: "checklists");

            migrationBuilder.AlterColumn<int>(
                name: "IdCheckList",
                table: "appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_checklists",
                table: "checklists",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_IdCheckList",
                table: "appointments",
                column: "IdCheckList",
                unique: true,
                filter: "[IdCheckList] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_checklists_IdCheckList",
                table: "appointments",
                column: "IdCheckList",
                principalTable: "checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_checklists_IdCheckList",
                table: "appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_checklists",
                table: "checklists");

            migrationBuilder.DropIndex(
                name: "IX_appointments_IdCheckList",
                table: "appointments");

            migrationBuilder.RenameTable(
                name: "checklists",
                newName: "CheckLists");

            migrationBuilder.AlterColumn<int>(
                name: "IdCheckList",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckLists",
                table: "CheckLists",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_IdCheckList",
                table: "appointments",
                column: "IdCheckList",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_CheckLists_IdCheckList",
                table: "appointments",
                column: "IdCheckList",
                principalTable: "CheckLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
