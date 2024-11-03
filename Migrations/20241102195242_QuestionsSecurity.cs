using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace refund.Migrations
{
    /// <inheritdoc />
    public partial class QuestionsSecurity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecurityQuestions",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityQuestions", x => x.QuestionID);
                });

            migrationBuilder.InsertData(
                table: "SecurityQuestions",
                columns: new[] { "QuestionID", "QuestionText" },
                values: new object[,]
                {
                    { 1, "What is the name of your first best friend?" },
                    { 2, "What is the name of the street you grew up on?" },
                    { 3, "What was the name of your first pet?" },
                    { 4, "What was your grandparent’s nickname?" },
                    { 5, "In what city were you born?" },
                    { 6, "What was the first concert you attended?" },
                    { 7, "What was your favorite childhood food?" },
                    { 8, "What was the name of your favorite elementary school teacher?" },
                    { 9, "Where did you spend your first vacation?" },
                    { 10, "What is the title of your all-time favorite movie?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityQuestions");
        }
    }
}
