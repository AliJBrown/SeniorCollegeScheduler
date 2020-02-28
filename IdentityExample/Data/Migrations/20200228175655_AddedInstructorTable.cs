using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeniorCollegeScheduler.Data.Migrations
{
    public partial class AddedInstructorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InstructorId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 25, nullable: true),
                    LastName = table.Column<string>(maxLength: 25, nullable: true),
                    StreetAddress = table.Column<string>(maxLength: 45, nullable: true),
                    city = table.Column<string>(maxLength: 25, nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: true),
                    ShareEmail = table.Column<bool>(nullable: false),
                    ShareMobilePhone = table.Column<bool>(nullable: false),
                    ShareLandline = table.Column<bool>(nullable: false),
                    LandlinePhone = table.Column<string>(maxLength: 10, nullable: true),
                    MobilePhone = table.Column<string>(maxLength: 10, nullable: true),
                    InstructorBio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InstructorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructor");
        }
    }
}
