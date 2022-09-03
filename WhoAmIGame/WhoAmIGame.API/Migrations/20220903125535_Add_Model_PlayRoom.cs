using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoAmIGame.Migrations
{
    public partial class Add_Model_PlayRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LobbyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPlayers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayRoom", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayRoom");
        }
    }
}
