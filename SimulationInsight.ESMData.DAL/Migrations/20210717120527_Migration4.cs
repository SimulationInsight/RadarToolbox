using Microsoft.EntityFrameworkCore.Migrations;

namespace SimulationInsight.ESMData.DAL.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recording_Mission_MissionId",
                table: "Recording");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_Mission_MissionId",
                table: "Track");

            migrationBuilder.AlterColumn<int>(
                name: "MissionId",
                table: "Track",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MissionId",
                table: "Recording",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recording_Mission_MissionId",
                table: "Recording",
                column: "MissionId",
                principalTable: "Mission",
                principalColumn: "MissionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Mission_MissionId",
                table: "Track",
                column: "MissionId",
                principalTable: "Mission",
                principalColumn: "MissionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recording_Mission_MissionId",
                table: "Recording");

            migrationBuilder.DropForeignKey(
                name: "FK_Track_Mission_MissionId",
                table: "Track");

            migrationBuilder.AlterColumn<int>(
                name: "MissionId",
                table: "Track",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MissionId",
                table: "Recording",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
