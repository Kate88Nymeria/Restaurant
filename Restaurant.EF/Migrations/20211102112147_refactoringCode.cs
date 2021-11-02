using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.EF.Migrations
{
    public partial class refactoringCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Menus_MenuID",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "MenuID",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Menus_MenuID",
                table: "Dishes",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Menus_MenuID",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "MenuID",
                table: "Dishes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Menus_MenuID",
                table: "Dishes",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
