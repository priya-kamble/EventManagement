using Microsoft.EntityFrameworkCore.Migrations;

namespace EventAPI.Migrations
{
    public partial class addFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormatId",
                table: "EventCatalog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    FormatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormatName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.FormatId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventCatalog_FormatId",
                table: "EventCatalog",
                column: "FormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCatalog_Formats_FormatId",
                table: "EventCatalog",
                column: "FormatId",
                principalTable: "Formats",
                principalColumn: "FormatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCatalog_Formats_FormatId",
                table: "EventCatalog");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropIndex(
                name: "IX_EventCatalog_FormatId",
                table: "EventCatalog");

            migrationBuilder.DropColumn(
                name: "FormatId",
                table: "EventCatalog");
        }
    }
}
