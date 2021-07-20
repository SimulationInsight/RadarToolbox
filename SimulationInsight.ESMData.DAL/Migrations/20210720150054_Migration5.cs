using Microsoft.EntityFrameworkCore.Migrations;

namespace SimulationInsight.ESMData.DAL.Migrations
{
    public partial class Migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FrequencyBandwidth",
                table: "PulseDescriptor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FrequencyCentre",
                table: "PulseDescriptor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrequencyBandwidth",
                table: "PulseDescriptor");

            migrationBuilder.DropColumn(
                name: "FrequencyCentre",
                table: "PulseDescriptor");
        }
    }
}
