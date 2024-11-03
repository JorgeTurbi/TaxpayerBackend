using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace refund.Migrations
{
    /// <inheritdoc />
    public partial class PeriodNoteField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PeriodNote",
                table: "TaxPreparer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodNote",
                table: "TaxPreparer");
        }
    }
}
