using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CartaLigeiros",
                table: "Characters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CartaMota",
                table: "Characters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CartaPesados",
                table: "Characters",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartaLigeiros",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CartaMota",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CartaPesados",
                table: "Characters");
        }
    }
}
