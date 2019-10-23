using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPL",
                table: "Buildings");

            migrationBuilder.AddColumn<int>(
                name: "EnterInterior",
                table: "Buildings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExitInterior",
                table: "Buildings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnterInterior",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "ExitInterior",
                table: "Buildings");

            migrationBuilder.AddColumn<string>(
                name: "IPL",
                table: "Buildings",
                nullable: true);
        }
    }
}
