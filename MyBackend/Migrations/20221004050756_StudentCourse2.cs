using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBackend.Migrations
{
    public partial class StudentCourse2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Students_StudentId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Courses",
                newName: "studentId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_StudentId",
                table: "Courses",
                newName: "IX_Courses_studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Students_studentId",
                table: "Courses",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Students_studentId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "studentId",
                table: "Courses",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_studentId",
                table: "Courses",
                newName: "IX_Courses_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Students_StudentId",
                table: "Courses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
