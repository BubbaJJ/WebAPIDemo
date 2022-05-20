using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIDemo.Migrations
{
    public partial class changedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Users_AssignedToId",
                table: "Todos");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedToId",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Users_AssignedToId",
                table: "Todos",
                column: "AssignedToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Users_AssignedToId",
                table: "Todos");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedToId",
                table: "Todos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Users_AssignedToId",
                table: "Todos",
                column: "AssignedToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
