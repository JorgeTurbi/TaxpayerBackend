using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace refund.Migrations
{
    /// <inheritdoc />
    public partial class PeriodNoteFieldupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PeriodNote",
                table: "TaxPreparer",
                newName: "Messages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Messages",
                table: "TaxPreparer",
                newName: "PeriodNote");
        }
    }
}
