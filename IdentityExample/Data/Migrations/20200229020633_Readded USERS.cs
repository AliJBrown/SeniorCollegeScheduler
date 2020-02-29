using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeniorCollegeScheduler.Data.Migrations
{
    public partial class ReaddedUSERS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    InstructorInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstructorId = table.Column<string>(maxLength: 40, nullable: true),
                    FirstName = table.Column<string>(maxLength: 25, nullable: true),
                    LastName = table.Column<string>(maxLength: 25, nullable: true),
                    StreetAddress = table.Column<string>(maxLength: 45, nullable: true),
                    City = table.Column<string>(maxLength: 25, nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: true),
                    ShareEmail = table.Column<bool>(nullable: false),
                    ShareMobilePhone = table.Column<bool>(nullable: false),
                    ShareLandline = table.Column<bool>(nullable: false),
                    LandlinePhone = table.Column<string>(maxLength: 10, nullable: true),
                    MobilePhone = table.Column<string>(maxLength: 10, nullable: true),
                    InstructorBio = table.Column<string>(nullable: true),
                    IsFiled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.InstructorInfoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
