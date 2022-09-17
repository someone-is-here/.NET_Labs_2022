using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_053501_Tatsiana_Shurko.Migrations
{
    public partial class AddContentTypeApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "AspNetUsers");
        }
    }
}
