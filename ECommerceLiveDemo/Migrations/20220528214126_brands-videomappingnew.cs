using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceLiveDemo.Migrations
{
    public partial class brandsvideomappingnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
           

            
            migrationBuilder.AddForeignKey(
                name: "FK_VideoBrandMapping_Brand_BrandId",
                table: "VideoBrandMapping",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoBrandMapping_Video_VideoId",
                table: "VideoBrandMapping",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoBrandMapping_Brand_BrandId",
                table: "VideoBrandMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoBrandMapping_Video_VideoId",
                table: "VideoBrandMapping");

           

           

            migrationBuilder.AlterColumn<int>(
                name: "VideoId",
                table: "Video_Brand_Mapping",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Video_Brand_Mapping",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Video_Brand_Mapping",
                table: "Video_Brand_Mapping",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Brand_Mapping_Brand",
                table: "Video_Brand_Mapping",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Brand_Mapping_Video",
                table: "Video_Brand_Mapping",
                column: "VideoId",
                principalTable: "Video",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
