using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatingtherelationshipbetweendepartmentandcoursemakingitmanytomanyrelated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_Department_Id",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "Department_Id",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DepartmentsCourses",
                columns: table => new
                {
                    DepartmentCourse_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_Id = table.Column<int>(type: "int", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsCourses", x => x.DepartmentCourse_Id);
                    table.ForeignKey(
                        name: "FK_DepartmentsCourses_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Courses",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentsCourses_Departments_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Departments",
                        principalColumn: "Department_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsCourses_Course_Id",
                table: "DepartmentsCourses",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsCourses_Department_Id",
                table: "DepartmentsCourses",
                column: "Department_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_Department_Id",
                table: "Courses",
                column: "Department_Id",
                principalTable: "Departments",
                principalColumn: "Department_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_Department_Id",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "DepartmentsCourses");

            migrationBuilder.AlterColumn<int>(
                name: "Department_Id",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_Department_Id",
                table: "Courses",
                column: "Department_Id",
                principalTable: "Departments",
                principalColumn: "Department_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
