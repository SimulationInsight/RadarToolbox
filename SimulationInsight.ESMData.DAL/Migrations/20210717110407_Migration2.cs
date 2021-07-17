using Microsoft.EntityFrameworkCore.Migrations;

namespace SimulationInsight.ESMData.DAL.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PulseDescriptors_Tracks_TrackId",
                table: "PulseDescriptors");

            migrationBuilder.DropForeignKey(
                name: "FK_Recordings_Missions_MissionId",
                table: "Recordings");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Missions_MissionId",
                table: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tracks",
                table: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recordings",
                table: "Recordings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PulseDescriptors",
                table: "PulseDescriptors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Missions",
                table: "Missions");

            migrationBuilder.RenameTable(
                name: "Tracks",
                newName: "Track");

            migrationBuilder.RenameTable(
                name: "Recordings",
                newName: "Recording");

            migrationBuilder.RenameTable(
                name: "PulseDescriptors",
                newName: "PulseDescriptor");

            migrationBuilder.RenameTable(
                name: "Missions",
                newName: "Mission");

            migrationBuilder.RenameIndex(
                name: "IX_Tracks_MissionId",
                table: "Track",
                newName: "IX_Track_MissionId");

            migrationBuilder.RenameIndex(
                name: "IX_Recordings_MissionId",
                table: "Recording",
                newName: "IX_Recording_MissionId");

            migrationBuilder.RenameIndex(
                name: "IX_PulseDescriptors_TrackId",
                table: "PulseDescriptor",
                newName: "IX_PulseDescriptor_TrackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Track",
                table: "Track",
                column: "TrackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recording",
                table: "Recording",
                column: "RecordingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PulseDescriptor",
                table: "PulseDescriptor",
                column: "PulseDescriptorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mission",
                table: "Mission",
                column: "MissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PulseDescriptor_Track_TrackId",
                table: "PulseDescriptor",
                column: "TrackId",
                principalTable: "Track",
                principalColumn: "TrackId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recording_Mission_MissionId",
                table: "Recording",
                column: "MissionId",
                principalTable: "Mission",
                principalColumn: "MissionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Mission_MissionId",
                table: "Track",
                column: "MissionId",
                principalTable: "Mission",
                principalColumn: "MissionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PulseDescriptor_Track_TrackId",
                table: "PulseDescriptor");

            migrationBuilder.DropForeignKey(
                name: "FK_Recording_Mission_MissionId",
                table: "Recording");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_Mission_MissionId",
                table: "Track");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Track",
                table: "Track");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recording",
                table: "Recording");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PulseDescriptor",
                table: "PulseDescriptor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mission",
                table: "Mission");

            migrationBuilder.RenameTable(
                name: "Track",
                newName: "Tracks");

            migrationBuilder.RenameTable(
                name: "Recording",
                newName: "Recordings");

            migrationBuilder.RenameTable(
                name: "PulseDescriptor",
                newName: "PulseDescriptors");

            migrationBuilder.RenameTable(
                name: "Mission",
                newName: "Missions");

            migrationBuilder.RenameIndex(
                name: "IX_Track_MissionId",
                table: "Tracks",
                newName: "IX_Tracks_MissionId");

            migrationBuilder.RenameIndex(
                name: "IX_Recording_MissionId",
                table: "Recordings",
                newName: "IX_Recordings_MissionId");

            migrationBuilder.RenameIndex(
                name: "IX_PulseDescriptor_TrackId",
                table: "PulseDescriptors",
                newName: "IX_PulseDescriptors_TrackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tracks",
                table: "Tracks",
                column: "TrackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recordings",
                table: "Recordings",
                column: "RecordingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PulseDescriptors",
                table: "PulseDescriptors",
                column: "PulseDescriptorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Missions",
                table: "Missions",
                column: "MissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PulseDescriptors_Tracks_TrackId",
                table: "PulseDescriptors",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "TrackId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recordings_Missions_MissionId",
                table: "Recordings",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "MissionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Missions_MissionId",
                table: "Tracks",
                column: "MissionId",
                principalTable: "Missions",
                principalColumn: "MissionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
