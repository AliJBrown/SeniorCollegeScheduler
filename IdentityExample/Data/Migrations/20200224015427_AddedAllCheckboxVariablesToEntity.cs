using Microsoft.EntityFrameworkCore.Migrations;

namespace SeniorCollegeScheduler.Data.Migrations
{
    public partial class AddedAllCheckboxVariablesToEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Podium",
                table: "ProposedClass",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Podium",
                table: "ProposedClass");
        }
    }
}
