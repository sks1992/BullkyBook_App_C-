using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BullkyBookWeb.Migrations
{
    public partial class ChangeTitleInProductsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Products",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Products",
                newName: "title");
        }
    }
}
