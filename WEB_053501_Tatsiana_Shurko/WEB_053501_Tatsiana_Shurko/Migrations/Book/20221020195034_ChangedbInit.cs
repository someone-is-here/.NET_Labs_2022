using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB_053501_Tatsiana_Shurko.Migrations.Book
{
    public partial class ChangedbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatgoryId",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatgoryId",
                table: "Books",
                type: "int",
                nullable: true);
        }
    }
}
