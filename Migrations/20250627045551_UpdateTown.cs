using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTown : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NRCTownships",
                columns: table => new
                {
                    NRC_pkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region = table.Column<int>(type: "int", nullable: false),
                    TownshipCode_M = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TownshipCode_E = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TownshipName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NRCTownships", x => x.NRC_pkId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_NRCTownship_pkId",
                table: "Students",
                column: "NRCTownship_pkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_NRCTownships_NRCTownship_pkId",
                table: "Students",
                column: "NRCTownship_pkId",
                principalTable: "NRCTownships",
                principalColumn: "NRC_pkId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_NRCTownships_NRCTownship_pkId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "NRCTownships");

            migrationBuilder.DropIndex(
                name: "IX_Students_NRCTownship_pkId",
                table: "Students");
        }
    }
}
