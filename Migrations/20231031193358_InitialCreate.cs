using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCompilerWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    FacultyNumber = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FacultyName = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AcademicDegreeName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AcademicDegreeType = table.Column<int>(type: "int", nullable: false),
                    Stream = table.Column<short>(type: "smallint", nullable: false),
                    Group = table.Column<short>(type: "smallint", nullable: false),
                    Semester = table.Column<short>(type: "smallint", nullable: false),
                    Course = table.Column<short>(type: "smallint", nullable: false),
                    StudyType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.FacultyNumber);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
