using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addingteachertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teacher_Teacher_Id",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Teacher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_Teacher_Id",
                table: "Courses",
                column: "Teacher_Id",
                principalTable: "Teachers",
                principalColumn: "Teacher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_Teacher_Id",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Teacher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teacher_Teacher_Id",
                table: "Courses",
                column: "Teacher_Id",
                principalTable: "Teacher",
                principalColumn: "Teacher_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
