using Microsoft.EntityFrameworkCore.Migrations;

namespace GymProject.DataAccess.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Progress");

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "Progress",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "Progress");

            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "Progress",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
