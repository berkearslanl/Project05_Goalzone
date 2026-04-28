using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoalZoneProject.WepApi.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeamSide",
                table: "MatchEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamSide",
                table: "MatchEvents");
        }
    }
}
