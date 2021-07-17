using Microsoft.EntityFrameworkCore.Migrations;

namespace SimulationInsight.ESMData.DAL.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PulseId",
                table: "PulseDescriptor",
                newName: "PulseNumber");

            migrationBuilder.AddColumn<int>(
                name: "TrackNumber",
                table: "Track",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecordingNumber",
                table: "Recording",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MissionNumber",
                table: "Mission",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrackNumber",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "RecordingNumber",
                table: "Recording");

            migrationBuilder.DropColumn(
                name: "MissionNumber",
                table: "Mission");

            migrationBuilder.RenameColumn(
                name: "PulseNumber",
                table: "PulseDescriptor",
                newName: "PulseId");
        }
    }
}
