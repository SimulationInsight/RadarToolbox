using Microsoft.EntityFrameworkCore.Migrations;

namespace SimulationInsight.ESMData.DAL.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amplitude",
                table: "IQSample",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "InstantaneousFrequency",
                table: "IQSample",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Phase",
                table: "IQSample",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Power",
                table: "IQSample",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Power_dB",
                table: "IQSample",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amplitude",
                table: "IQSample");

            migrationBuilder.DropColumn(
                name: "InstantaneousFrequency",
                table: "IQSample");

            migrationBuilder.DropColumn(
                name: "Phase",
                table: "IQSample");

            migrationBuilder.DropColumn(
                name: "Power",
                table: "IQSample");

            migrationBuilder.DropColumn(
                name: "Power_dB",
                table: "IQSample");
        }
    }
}
