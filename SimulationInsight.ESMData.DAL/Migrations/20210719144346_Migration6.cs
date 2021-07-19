using Microsoft.EntityFrameworkCore.Migrations;

namespace SimulationInsight.ESMData.DAL.Migrations
{
    public partial class Migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PulseDescriptor_Track_TrackId",
                table: "PulseDescriptor");

            migrationBuilder.AlterColumn<int>(
                name: "TrackId",
                table: "PulseDescriptor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PulseDescriptor_Track_TrackId",
                table: "PulseDescriptor",
                column: "TrackId",
                principalTable: "Track",
                principalColumn: "TrackId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PulseDescriptor_Track_TrackId",
                table: "PulseDescriptor");

            migrationBuilder.AlterColumn<int>(
                name: "TrackId",
                table: "PulseDescriptor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PulseDescriptor_Track_TrackId",
                table: "PulseDescriptor",
                column: "TrackId",
                principalTable: "Track",
                principalColumn: "TrackId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
