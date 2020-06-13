using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Status.Domain.Migrations
{
    public partial class AddNameColumnToStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Status",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Status");
        }
    }
}
