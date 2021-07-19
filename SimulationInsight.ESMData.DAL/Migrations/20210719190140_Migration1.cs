using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimulationInsight.ESMData.DAL.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    MissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionNumber = table.Column<int>(type: "int", nullable: false),
                    MissionType = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.MissionId);
                });

            migrationBuilder.CreateTable(
                name: "Recording",
                columns: table => new
                {
                    RecordingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordingNumber = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileName = table.Column<int>(type: "int", nullable: false),
                    MissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recording", x => x.RecordingId);
                    table.ForeignKey(
                        name: "FK_Recording_Mission_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Mission",
                        principalColumn: "MissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackNumber = table.Column<int>(type: "int", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrackName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.TrackId);
                    table.ForeignKey(
                        name: "FK_Track_Mission_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Mission",
                        principalColumn: "MissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PulseDescriptor",
                columns: table => new
                {
                    PulseDescriptorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PulseNumber = table.Column<int>(type: "int", nullable: false),
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
                    TrackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PulseDescriptor", x => x.PulseDescriptorId);
                    table.ForeignKey(
                        name: "FK_PulseDescriptor_Track_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Track",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IQSample",
                columns: table => new
                {
                    IQSampleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SampleNumber = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    I = table.Column<double>(type: "float", nullable: false),
                    Q = table.Column<double>(type: "float", nullable: false),
                    PulseDescriptorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IQSample", x => x.IQSampleId);
                    table.ForeignKey(
                        name: "FK_IQSample_PulseDescriptor_PulseDescriptorId",
                        column: x => x.PulseDescriptorId,
                        principalTable: "PulseDescriptor",
                        principalColumn: "PulseDescriptorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IQSample_PulseDescriptorId",
                table: "IQSample",
                column: "PulseDescriptorId");

            migrationBuilder.CreateIndex(
                name: "IX_PulseDescriptor_TrackId",
                table: "PulseDescriptor",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Recording_MissionId",
                table: "Recording",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_MissionId",
                table: "Track",
                column: "MissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IQSample");

            migrationBuilder.DropTable(
                name: "Recording");

            migrationBuilder.DropTable(
                name: "PulseDescriptor");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Mission");
        }
    }
}
