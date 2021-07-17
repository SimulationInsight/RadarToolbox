using Microsoft.EntityFrameworkCore.Migrations;

namespace SimulationInsight.ESMData.DAL.Migrations
{
    public partial class Migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MissionType",
                table: "Mission",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MissionType",
                table: "Mission");
        }
    }
}
