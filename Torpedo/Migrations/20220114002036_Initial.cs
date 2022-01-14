using Microsoft.EntityFrameworkCore.Migrations;

namespace Torpedo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player1Name = table.Column<string>(nullable: true),
                    Player2Name = table.Column<string>(nullable: true),
                    NumberOfTurns = table.Column<int>(nullable: false),
                    NumberOfPlayer1Hits = table.Column<int>(nullable: false),
                    NumberOfPlayer2Hits = table.Column<int>(nullable: false),
                    WinnerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
