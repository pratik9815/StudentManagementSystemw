using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Department_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Department_Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Student_Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Course_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course_Year = table.Column<int>(type: "int", nullable: false),
                    Course_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Course_Id);
                    table.ForeignKey(
                        name: "FK_Courses_Department_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Department",
                        principalColumn: "Department_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCourse",
                columns: table => new
                {
                    Student_Id = table.Column<int>(type: "int", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    StudentCourseCourse_Id = table.Column<int>(type: "int", nullable: true),
                    StudentCourseStudent_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCourse", x => new { x.Student_Id, x.Course_Id });
                    table.ForeignKey(
                        name: "FK_StudentsCourse_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Courses",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsCourse_StudentsCourse_StudentCourseStudent_Id_StudentCourseCourse_Id",
                        columns: x => new { x.StudentCourseStudent_Id, x.StudentCourseCourse_Id },
                        principalTable: "StudentsCourse",
                        principalColumns: new[] { "Student_Id", "Course_Id" });
                    table.ForeignKey(
                        name: "FK_StudentsCourse_Students_Student_Id",
                        column: x => x.Student_Id,
                        principalTable: "Students",
                        principalColumn: "Student_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Department_Id",
                table: "Courses",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourse_Course_Id",
                table: "StudentsCourse",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourse_StudentCourseStudent_Id_StudentCourseCourse_Id",
                table: "StudentsCourse",
                columns: new[] { "StudentCourseStudent_Id", "StudentCourseCourse_Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsCourse");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
