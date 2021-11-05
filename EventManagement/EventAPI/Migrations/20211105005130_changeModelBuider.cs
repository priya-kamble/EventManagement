using Microsoft.EntityFrameworkCore.Migrations;

namespace EventAPI.Migrations
{
    public partial class changeModelBuider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCatalog_SubCategories_SubCategoryId",
                table: "EventCatalog");

            migrationBuilder.DropIndex(
                name: "IX_EventCatalog_SubCategoryId",
                table: "EventCatalog");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EventCatalog",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCatalog_SubCategories_Id",
                table: "EventCatalog",
                column: "Id",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCatalog_SubCategories_Id",
                table: "EventCatalog");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EventCatalog",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_EventCatalog_SubCategoryId",
                table: "EventCatalog",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCatalog_SubCategories_SubCategoryId",
                table: "EventCatalog",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
