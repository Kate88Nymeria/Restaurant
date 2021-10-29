using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.EF.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishName = table.Column<string>(maxLength: 30, nullable: false),
                    DishType = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    MenuID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "MenuName" },
                values: new object[,]
                {
                    { 1, "Christmas 2021 Menu" },
                    { 2, "Summer 2021 Menu" },
                    { 3, "Winter 2021 Menu" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "mrossi@diner.it", "1234", 0 },
                    { 2, "pbianchi@mail.it", "5678", 1 },
                    { 3, "gverdi@mail.it", "9876", 1 }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "DishName", "DishType", "MenuID", "Price" },
                values: new object[] { 1, "Lasagne", 0, 1, 8.20m });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "DishName", "DishType", "MenuID", "Price" },
                values: new object[] { 3, "Cheesecake", 3, 2, 5.30m });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "DishName", "DishType", "MenuID", "Price" },
                values: new object[] { 2, "Fish and Chips", 1, 3, 6.90m });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_MenuID",
                table: "Dishes",
                column: "MenuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
