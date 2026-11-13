using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanceAcademy.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Enquiries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Enquiries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreferredClassTiming",
                table: "Enquiries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "Enquiries",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Enquiries");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Enquiries");

            migrationBuilder.DropColumn(
                name: "PreferredClassTiming",
                table: "Enquiries");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "Enquiries");
        }
    }
}
