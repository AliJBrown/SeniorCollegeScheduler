using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeniorCollegeScheduler.Data.Migrations
{
    public partial class AddedProposedClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProposedClass",
                columns: table => new
                {
                    ProposedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProposedDate = table.Column<DateTime>(nullable: false),
                    ProposedTitle = table.Column<string>(nullable: true),
                    NumberOfSessions = table.Column<int>(nullable: false),
                    LengthOfSession = table.Column<int>(nullable: false),
                    CourseDescription = table.Column<string>(nullable: true),
                    PreRequisite = table.Column<string>(nullable: true),
                    UnavailableTimes = table.Column<string>(nullable: true),
                    MinStudentCount = table.Column<int>(nullable: false),
                    MaxStudentCount = table.Column<int>(nullable: false),
                    ChairsNeeded = table.Column<int>(nullable: false),
                    TablesNeeded = table.Column<int>(nullable: false),
                    HandoutCost = table.Column<double>(nullable: false),
                    StipendRequested = table.Column<bool>(nullable: false),
                    OtherEquipmentNeeded = table.Column<string>(nullable: true),
                    InternetConnection = table.Column<bool>(nullable: false),
                    DryEraseBoard = table.Column<bool>(nullable: false),
                    ProjectorWithScreen = table.Column<bool>(nullable: false),
                    PCConnectionType = table.Column<string>(nullable: true),
                    MicrophoneAndSound = table.Column<bool>(nullable: false),
                    DVDAndVCRPlayer = table.Column<bool>(nullable: false),
                    MondayEvening = table.Column<bool>(nullable: false),
                    MondayMorning = table.Column<bool>(nullable: false),
                    MondayAfternoon = table.Column<bool>(nullable: false),
                    TuesdayEvening = table.Column<bool>(nullable: false),
                    TuesdayMorning = table.Column<bool>(nullable: false),
                    TuesdayAfternoon = table.Column<bool>(nullable: false),
                    WednesdayEvening = table.Column<bool>(nullable: false),
                    WednesdayMorning = table.Column<bool>(nullable: false),
                    WednesdayAfternoon = table.Column<bool>(nullable: false),
                    ThursdayEvening = table.Column<bool>(nullable: false),
                    ThursdayMorning = table.Column<bool>(nullable: false),
                    ThursdayAfternoon = table.Column<bool>(nullable: false),
                    FridayEvening = table.Column<bool>(nullable: false),
                    FridayMorning = table.Column<bool>(nullable: false),
                    FridayAfternoon = table.Column<bool>(nullable: false),
                    SaturdayEvening = table.Column<bool>(nullable: false),
                    SaturdayMorning = table.Column<bool>(nullable: false),
                    SaturdayAfternoon = table.Column<bool>(nullable: false),
                    SundayEvening = table.Column<bool>(nullable: false),
                    SundayMorning = table.Column<bool>(nullable: false),
                    SundayAfternoon = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposedClass", x => x.ProposedID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProposedClass");
        }
    }
}
