using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class correctingthestudentcoursetableandaddingothertables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsCourse_StudentsCourse_StudentCourseStudent_Id_StudentCourseCourse_Id",
                table: "StudentsCourse");

            migrationBuilder.DropIndex(
                name: "IX_StudentsCourse_StudentCourseStudent_Id_StudentCourseCourse_Id",
                table: "StudentsCourse");

            migrationBuilder.DropColumn(
                name: "StudentCourseCourse_Id",
                table: "StudentsCourse");

            migrationBuilder.DropColumn(
                name: "StudentCourseStudent_Id",
                table: "StudentsCourse");

            migrationBuilder.AddColumn<int>(
                name: "Teacher_Id",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Teacher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Teacher_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Teacher_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Teacher_Id",
                table: "Courses",
                column: "Teacher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teacher_Teacher_Id",
                table: "Courses",
                column: "Teacher_Id",
                principalTable: "Teacher",
                principalColumn: "Teacher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teacher_Teacher_Id",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Teacher_Id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Teacher_Id",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "StudentCourseCourse_Id",
                table: "StudentsCourse",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentCourseStudent_Id",
                table: "StudentsCourse",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourse_StudentCourseStudent_Id_StudentCourseCourse_Id",
                table: "StudentsCourse",
                columns: new[] { "StudentCourseStudent_Id", "StudentCourseCourse_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsCourse_StudentsCourse_StudentCourseStudent_Id_StudentCourseCourse_Id",
                table: "StudentsCourse",
                columns: new[] { "StudentCourseStudent_Id", "StudentCourseCourse_Id" },
                principalTable: "StudentsCourse",
                principalColumns: new[] { "Student_Id", "Course_Id" });
        }
    }
}
