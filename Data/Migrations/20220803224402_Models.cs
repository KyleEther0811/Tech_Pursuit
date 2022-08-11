using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tech_Pursuit.Data.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Language_AspNetUsers_AppUserId",
                table: "Language");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languages");

            migrationBuilder.RenameIndex(
                name: "IX_Language_AppUserId",
                table: "Languages",
                newName: "IX_Languages_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CoverLetter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    AboutCompany = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CompanyWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RequiredSkills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayRate = table.Column<double>(type: "float", nullable: false),
                    Benefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobModels", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_AspNetUsers_AppUserId",
                table: "Languages",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_AspNetUsers_AppUserId",
                table: "Languages");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "JobModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language");

            migrationBuilder.RenameIndex(
                name: "IX_Languages_AppUserId",
                table: "Language",
                newName: "IX_Language_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Language_AspNetUsers_AppUserId",
                table: "Language",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
