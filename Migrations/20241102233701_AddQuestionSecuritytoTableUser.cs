using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace refund.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionSecuritytoTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Question",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Response",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Response",
                table: "User");
        }
    }
}
