using Microsoft.EntityFrameworkCore.Migrations;

namespace SeniorCollegeScheduler.Data.Migrations
{
    public partial class AddedProposedByIDtoProposedClassTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProposedById",
                table: "ProposedClass",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProposedById",
                table: "ProposedClass");
        }
    }
}
