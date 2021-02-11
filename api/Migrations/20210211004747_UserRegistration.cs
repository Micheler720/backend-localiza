using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class UserRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "users",
                newName: "Cpf");

            migrationBuilder.AlterColumn<string>(
                name: "Registration",
                table: "users",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "users",
                newName: "CPF");

            migrationBuilder.AlterColumn<string>(
                name: "Registration",
                table: "users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}
