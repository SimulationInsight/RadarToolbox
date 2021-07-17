using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimulationInsight.ESMData.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    MissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.MissionId);
                });

            migrationBuilder.CreateTable(
                name: "Recordings",
                columns: table => new
                {
                    RecordingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileName = table.Column<int>(type: "int", nullable: false),
                    MissionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recordings", x => x.RecordingId);
                    table.ForeignKey(
                        name: "FK_Recordings_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "MissionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrackName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.TrackId);
                    table.ForeignKey(
                        name: "FK_Tracks_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "MissionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PulseDescriptors",
                columns: table => new
                {
                    PulseDescriptorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PulseId = table.Column<int>(type: "int", nullable: false),
                    PulseTimeStart = table.Column<double>(type: "float", nullable: false),
                    PulseTimeEnd = table.Column<double>(type: "float", nullable: false),
                    PulseWidth = table.Column<double>(type: "float", nullable: false),
                    PulseModulationType = table.Column<double>(type: "float", nullable: false),
                    FrequencyStart = table.Column<double>(type: "float", nullable: false),
                    FrequencyEnd = table.Column<double>(type: "float", nullable: false),
                    FrequencyRampRate = table.Column<double>(type: "float", nullable: false),
                    SignalPower = table.Column<double>(type: "float", nullable: false),
                    SignalToNoiseRatio = table.Column<double>(type: "float", nullable: false),
                    AzimuthAngleDeg = table.Column<double>(type: "float", nullable: false),
                    ElevationAngleDeg = table.Column<double>(type: "float", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PulseDescriptors", x => x.PulseDescriptorId);
                    table.ForeignKey(
                        name: "FK_PulseDescriptors_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PulseDescriptors_TrackId",
                table: "PulseDescriptors",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Recordings_MissionId",
                table: "Recordings",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_MissionId",
                table: "Tracks",
                column: "MissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PulseDescriptors");

            migrationBuilder.DropTable(
                name: "Recordings");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Missions");
        }
    }
}
