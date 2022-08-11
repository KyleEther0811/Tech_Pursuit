using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tech_Pursuit.Data.Migrations
{
    public partial class isDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "JobModels",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "JobModels");
        }
    }
}
