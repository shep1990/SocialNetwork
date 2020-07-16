using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Friends.Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RequestUserId = table.Column<Guid>(nullable: false),
                    TargetUserId = table.Column<Guid>(nullable: false),
                    RequestAccepted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friend_Id",
                table: "Friend",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friend");
        }
    }
}
