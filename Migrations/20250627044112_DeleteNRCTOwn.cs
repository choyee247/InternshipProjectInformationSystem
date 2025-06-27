using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class DeleteNRCTOwn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_NRCRegionCodes_NRCRegionCode_pkId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_NRCTownships_NRCTownship_pkId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "NRCTownships");

            migrationBuilder.DropTable(
                name: "NRCRegionCodes");

            migrationBuilder.DropIndex(
                name: "IX_Students_NRCRegionCode_pkId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_NRCTownship_pkId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Frameworks",
                keyColumn: "Framework_pkId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "NRCTypes",
                keyColumn: "NRCType_pkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NRCTypes",
                keyColumn: "NRCType_pkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NRCTypes",
                keyColumn: "NRCType_pkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NRCTypes",
                keyColumn: "NRCType_pkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ProjectType_pkId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "StudentDepartments",
                keyColumn: "Department_pkID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentDepartments",
                keyColumn: "Department_pkID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Language_pkId",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "NRCRegionCode_pkId",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NRCRegionCode_pkId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NRCRegionCodes",
                columns: table => new
                {
                    NRCRegionCode_pkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NRCRegionCodes", x => x.NRCRegionCode_pkId);
                });

            migrationBuilder.CreateTable(
                name: "NRCTownships",
                columns: table => new
                {
                    NRCTownship_pkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NRCRegionCodeId = table.Column<int>(type: "int", nullable: false),
                    Township = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NRCTownships", x => x.NRCTownship_pkId);
                    table.ForeignKey(
                        name: "FK_NRCTownships_NRCRegionCodes_NRCRegionCodeId",
                        column: x => x.NRCRegionCodeId,
                        principalTable: "NRCRegionCodes",
                        principalColumn: "NRCRegionCode_pkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Language_pkId", "LanguageName" },
                values: new object[,]
                {
                    { 1, "Python" },
                    { 2, "JavaScript" },
                    { 3, "TypeScript" },
                    { 4, "C#" },
                    { 5, "Java" },
                    { 6, "Go" },
                    { 7, "Rust" },
                    { 8, "Kotlin" },
                    { 9, "Swift" },
                    { 10, "Dart" },
                    { 11, "PHP" },
                    { 12, "Ruby" },
                    { 13, "Scala" },
                    { 14, "SQL" },
                    { 15, "Shell" }
                });

            migrationBuilder.InsertData(
                table: "NRCRegionCodes",
                columns: new[] { "NRCRegionCode_pkId", "RegionCode" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" },
                    { 3, "3" },
                    { 4, "4" },
                    { 5, "5" },
                    { 6, "6" },
                    { 7, "7" },
                    { 8, "8" },
                    { 9, "9" },
                    { 10, "10" },
                    { 11, "11" },
                    { 12, "12" },
                    { 13, "13" },
                    { 14, "14" },
                    { 15, "15" }
                });

            migrationBuilder.InsertData(
                table: "NRCTypes",
                columns: new[] { "NRCType_pkId", "TypeCode", "TypeDescription" },
                values: new object[,]
                {
                    { 1, "N", "National" },
                    { 2, "E", "Elder" },
                    { 3, "P", "Permanent" },
                    { 4, "C", "Child" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTypes",
                columns: new[] { "ProjectType_pkId", "TypeName" },
                values: new object[,]
                {
                    { 1, "Web Application" },
                    { 2, "Mobile Application" },
                    { 3, "Desktop Application" },
                    { 4, "API Development" },
                    { 5, "Library / SDK" },
                    { 6, "Microservices" },
                    { 7, "Cloud Service" },
                    { 8, "Embedded System" },
                    { 9, "IoT Application" },
                    { 10, "Game Development" },
                    { 11, "Progressive Web App (PWA)" },
                    { 12, "Cross-platform Application" },
                    { 13, "Single Page Application (SPA)" },
                    { 14, "Enterprise Application" },
                    { 15, "Chatbot / AI Application" }
                });

            migrationBuilder.InsertData(
                table: "StudentDepartments",
                columns: new[] { "Department_pkID", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Computer Science" },
                    { 2, "Information Technology" }
                });

            migrationBuilder.InsertData(
                table: "Frameworks",
                columns: new[] { "Framework_pkId", "FrameworkName", "Language_pkId" },
                values: new object[,]
                {
                    { 1, "ASP.NET Core", 4 },
                    { 2, "React", 2 },
                    { 3, "Angular", 2 },
                    { 4, "Vue.js", 2 },
                    { 5, "Node.js", 2 },
                    { 6, "Django", 1 },
                    { 7, "Flask", 1 },
                    { 8, "Spring Boot", 5 },
                    { 9, "Laravel", 11 },
                    { 10, "Ruby on Rails", 12 },
                    { 11, "Flutter", 10 },
                    { 12, "Express.js", 2 },
                    { 13, "ASP.NET MVC", 4 },
                    { 14, "Electron", 2 },
                    { 15, "Svelte", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_NRCRegionCode_pkId",
                table: "Students",
                column: "NRCRegionCode_pkId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_NRCTownship_pkId",
                table: "Students",
                column: "NRCTownship_pkId");

            migrationBuilder.CreateIndex(
                name: "IX_NRCTownships_NRCRegionCodeId",
                table: "NRCTownships",
                column: "NRCRegionCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_NRCRegionCodes_NRCRegionCode_pkId",
                table: "Students",
                column: "NRCRegionCode_pkId",
                principalTable: "NRCRegionCodes",
                principalColumn: "NRCRegionCode_pkId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_NRCTownships_NRCTownship_pkId",
                table: "Students",
                column: "NRCTownship_pkId",
                principalTable: "NRCTownships",
                principalColumn: "NRCTownship_pkId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
