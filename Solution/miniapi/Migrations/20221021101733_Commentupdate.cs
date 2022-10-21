using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace miniapi.Migrations
{
    public partial class Commentupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Authorname",
                table: "Comments",
                newName: "Author");

            migrationBuilder.AddColumn<int>(
                name: "Post_Id",
                table: "Comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Post_Id",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Comments",
                newName: "Authorname");
        }
    }
}
