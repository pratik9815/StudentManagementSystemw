using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Department_Department_Id",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.AddColumn<DateTime>(
                name: "EnrollmentDate",
                table: "StudentsCourse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Department_Id");

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Grade_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student_Grade = table.Column<int>(type: "int", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    Student_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Grade_Id);
                    table.ForeignKey(
                        name: "FK_Grades_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Courses",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Students_Student_Id",
                        column: x => x.Student_Id,
                        principalTable: "Students",
                        principalColumn: "Student_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Course_Id",
                table: "Grades",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Student_Id",
                table: "Grades",
                column: "Student_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_Department_Id",
                table: "Courses",
                column: "Department_Id",
                principalTable: "Departments",
                principalColumn: "Department_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_Department_Id",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "EnrollmentDate",
                table: "StudentsCourse");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Department_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Department_Department_Id",
                table: "Courses",
                column: "Department_Id",
                principalTable: "Department",
                principalColumn: "Department_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
