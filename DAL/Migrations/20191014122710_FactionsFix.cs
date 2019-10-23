using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class FactionsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "DroppedItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DroppedItems");

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Faction_Name = table.Column<string>(nullable: false),
                    Faction_Owner = table.Column<string>(nullable: true),
                    Faction_Type = table.Column<int>(nullable: false),
                    Faction_Rank1 = table.Column<string>(nullable: true),
                    Faction_Rank2 = table.Column<string>(nullable: true),
                    Faction_Rank3 = table.Column<string>(nullable: true),
                    Faction_Rank4 = table.Column<string>(nullable: true),
                    Faction_Rank5 = table.Column<string>(nullable: true),
                    Faction_Rank6 = table.Column<string>(nullable: true),
                    Faction_Rank7 = table.Column<string>(nullable: true),
                    Faction_Banco = table.Column<int>(nullable: false),
                    Faction_Salary_1 = table.Column<int>(nullable: false),
                    Faction_Salary_2 = table.Column<int>(nullable: false),
                    Faction_Salary_3 = table.Column<int>(nullable: false),
                    Faction_Salary_4 = table.Column<int>(nullable: false),
                    Faction_Salary_5 = table.Column<int>(nullable: false),
                    Faction_Salary_6 = table.Column<int>(nullable: false),
                    Faction_Salary_7 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Faction_Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "DroppedItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DroppedItems",
                nullable: true);
        }
    }
}
