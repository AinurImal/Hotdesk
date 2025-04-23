using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotdesk.Migrations
{
    /// <inheritdoc />
    public partial class Desk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    DeskId = table.Column<int>(type: "int", nullable: false), // Removed Identity
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasMonitor = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.DeskId);
                });

            // No hardcoded data; ready for user input
        }




        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desk");
        }
    }
}
