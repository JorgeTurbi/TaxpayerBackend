using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace refund.Migrations
{
    /// <inheritdoc />
    public partial class FieldsRange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Range_End",
                table: "State",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Range_Start",
                table: "State",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Range_End",
                table: "State");

            migrationBuilder.DropColumn(
                name: "Range_Start",
                table: "State");
        }
    }
}
