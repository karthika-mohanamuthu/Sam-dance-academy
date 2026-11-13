using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DanceAcademy.Migrations
{
    /// <inheritdoc />
    public partial class AddEnquiryStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Enquiries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "New");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Enquiries");
        }
    }
}
