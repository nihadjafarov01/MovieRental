using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRental.DAL.Migrations
{
    public partial class ChangedIsPublicColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "WatchLists");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "AspNetUsers",
                type: "boolean",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "WatchLists",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
