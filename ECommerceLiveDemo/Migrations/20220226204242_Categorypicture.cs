using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceLiveDemo.Migrations
{
    public partial class Categorypicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryPicture",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryPicture",
                table: "Category");
        }
    }
}
