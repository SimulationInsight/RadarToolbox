using Microsoft.EntityFrameworkCore.Migrations;

namespace SimulationInsight.ESMData.DAL.Migrations
{
    public partial class Migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FrequencyBandwidth_MHz",
                table: "PulseDescriptor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FrequencyCentre_MHz",
                table: "PulseDescriptor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FrequencyEnd_MHz",
                table: "PulseDescriptor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FrequencyRampRate_THz_s",
                table: "PulseDescriptor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FrequencyStart_MHz",
                table: "PulseDescriptor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PulseWidth_us",
                table: "PulseDescriptor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SignalPower_dB",
                table: "PulseDescriptor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SignalPower_dBm",
                table: "PulseDescriptor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SignalToNoiseRatio_dB",
                table: "PulseDescriptor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FrequencyBandwidth_MHz",
                table: "PulseDescriptor");

            migrationBuilder.DropColumn(
                name: "FrequencyCentre_MHz",
                table: "PulseDescriptor");

            migrationBuilder.DropColumn(
                name: "FrequencyEnd_MHz",
                table: "PulseDescriptor");

            migrationBuilder.DropColumn(
                name: "FrequencyRampRate_THz_s",
                table: "PulseDescriptor");

            migrationBuilder.DropColumn(
                name: "FrequencyStart_MHz",
                table: "PulseDescriptor");

            migrationBuilder.DropColumn(
                name: "PulseWidth_us",
                table: "PulseDescriptor");

            migrationBuilder.DropColumn(
                name: "SignalPower_dB",
                table: "PulseDescriptor");

            migrationBuilder.DropColumn(
                name: "SignalPower_dBm",
                table: "PulseDescriptor");

            migrationBuilder.DropColumn(
                name: "SignalToNoiseRatio_dB",
                table: "PulseDescriptor");
        }
    }
}
