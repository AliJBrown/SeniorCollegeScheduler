using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeniorCollegeScheduler.Data.Migrations
{
    public partial class DroppingUSERS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    InstructorInfoId = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(maxLength: 25, nullable: true),
                    FirstName = table.Column<string>(maxLength: 25, nullable: true),
                    InstructorBio = table.Column<string>(nullable: true),
                    InstructorId = table.Column<string>(maxLength: 40, nullable: true),
                    IsFiled = table.Column<bool>(nullable: false),
                    LandlinePhone = table.Column<string>(maxLength: 10, nullable: true),
                    LastName = table.Column<string>(maxLength: 25, nullable: true),
                    MobilePhone = table.Column<string>(maxLength: 10, nullable: true),
                    ShareEmail = table.Column<bool>(nullable: false),
                    ShareLandline = table.Column<bool>(nullable: false),
                    ShareMobilePhone = table.Column<bool>(nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    StreetAddress = table.Column<string>(maxLength: 45, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.InstructorInfoId);
                });
        }
    }
}
