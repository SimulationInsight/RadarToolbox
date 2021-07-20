using Microsoft.EntityFrameworkCore.Migrations;

namespace SimulationInsight.ESMData.DAL.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpectrumSample",
                columns: table => new
                {
                    SpectrumSampleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SampleNumber = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<double>(type: "float", nullable: false),
                    Real = table.Column<double>(type: "float", nullable: false),
                    Imag = table.Column<double>(type: "float", nullable: false),
                    Amplitude = table.Column<double>(type: "float", nullable: false),
                    Power = table.Column<double>(type: "float", nullable: false),
                    Power_dB = table.Column<double>(type: "float", nullable: false),
                    PulseDescriptorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpectrumSample", x => x.SpectrumSampleId);
                    table.ForeignKey(
                        name: "FK_SpectrumSample_PulseDescriptor_PulseDescriptorId",
                        column: x => x.PulseDescriptorId,
                        principalTable: "PulseDescriptor",
                        principalColumn: "PulseDescriptorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpectrumSample_PulseDescriptorId",
                table: "SpectrumSample",
                column: "PulseDescriptorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpectrumSample");
        }
    }
}
