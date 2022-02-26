using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceLiveDemo.Migrations
{
    public partial class UrunUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductUrl",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductUrl",
                table: "Product");
        }
    }
}
