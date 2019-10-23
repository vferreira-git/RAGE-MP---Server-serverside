using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "LastX",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LastY",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LastZ",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Rotation",
                table: "Characters",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastX",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LastY",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "LastZ",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Rotation",
                table: "Characters");
        }
    }
}
