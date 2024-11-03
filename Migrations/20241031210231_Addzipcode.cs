using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace refund.Migrations
{
    /// <inheritdoc />
    public partial class Addzipcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Zipcode",
                table: "TaxPreparer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "TaxPreparer");
        }
    }
}
