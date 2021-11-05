using Microsoft.EntityFrameworkCore.Migrations;

namespace EventAPI.Migrations
{
    public partial class changeSubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                table: "SubCategories",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubCategories",
                newName: "SubCategoryId");
        }
    }
}
