using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class hihi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionCode",
                table: "NRCTownships");

            migrationBuilder.AddColumn<string>(
                name: "RegionCode_E",
                table: "NRCTownships",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionCode_M",
                table: "NRCTownships",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionCode_E",
                table: "NRCTownships");

            migrationBuilder.DropColumn(
                name: "RegionCode_M",
                table: "NRCTownships");

            migrationBuilder.AddColumn<int>(
                name: "RegionCode",
                table: "NRCTownships",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
