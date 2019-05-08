using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace routine_explorer.Migrations.Database
{
    public partial class ModelsCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserIP = table.Column<string>(nullable: false),
                    UserLocation = table.Column<string>(nullable: false),
                    AreaAccessed = table.Column<string>(nullable: false),
                    ActionDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: false),
                    UserEmail = table.Column<string>(nullable: false),
                    UserRating = table.Column<int>(nullable: false),
                    Suggestion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoutineFileUploaderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameOfFilesUploaded = table.Column<string>(nullable: false),
                    statusOfPublish = table.Column<bool>(nullable: false),
                    TimeOfUpload = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineFileUploaderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomNumber = table.Column<string>(nullable: false),
                    CourseCode = table.Column<string>(nullable: false),
                    Teacher = table.Column<string>(nullable: false),
                    DayOfWeek = table.Column<string>(nullable: false),
                    TimeRange = table.Column<string>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routine_RoutineFileUploaderStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "RoutineFileUploaderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Routine_StatusId",
                table: "Routine",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Routine");

            migrationBuilder.DropTable(
                name: "RoutineFileUploaderStatus");
        }
    }
}
