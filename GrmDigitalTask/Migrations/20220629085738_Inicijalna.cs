using Microsoft.EntityFrameworkCore.Migrations;

namespace GrmDigitalTask.Migrations
{
    public partial class Inicijalna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrmTask",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrmTask", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "GrmTask",
                columns: new[] { "ID", "Name", "Position", "Score" },
                values: new object[,]
                {
                    { 1, "Item1", 0, 0 },
                    { 2, "Item2", 0, 0 },
                    { 3, "Item3", 0, 0 },
                    { 4, "Item4", 0, 0 },
                    { 5, "Item5", 0, 0 },
                    { 6, "Item6", 0, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrmTask");
        }
    }
}
