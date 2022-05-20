using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIDemo.Migrations
{
    public partial class addedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedToId",
                table: "Todos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_AssignedToId",
                table: "Todos",
                column: "AssignedToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Users_AssignedToId",
                table: "Todos",
                column: "AssignedToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Users_AssignedToId",
                table: "Todos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Todos_AssignedToId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "AssignedToId",
                table: "Todos");
        }
    }
}
