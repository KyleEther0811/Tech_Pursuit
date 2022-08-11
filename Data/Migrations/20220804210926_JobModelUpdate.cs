using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tech_Pursuit.Data.Migrations
{
    public partial class JobModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "JobModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "JobModels");
        }
    }
}
