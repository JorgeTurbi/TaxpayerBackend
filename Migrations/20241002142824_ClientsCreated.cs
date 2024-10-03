using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace refund.Migrations
{
    /// <inheritdoc />
    public partial class ClientsCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpouseYTDFederalWithholding",
                table: "Spouse",
                newName: "SpouseYtdIncome");

            migrationBuilder.RenameColumn(
                name: "SpouseYTDEarnings",
                table: "Spouse",
                newName: "SpouseYtdFederal");

            migrationBuilder.RenameColumn(
                name: "SpouseWagesIncome",
                table: "Spouse",
                newName: "SpouseWagesFederal");

            migrationBuilder.RenameColumn(
                name: "SpouseSelfEmploymentCompensation",
                table: "Spouse",
                newName: "SpouseSelfEmploymentComp");

            migrationBuilder.RenameColumn(
                name: "SpouseFederalIncomeTaxWithheld",
                table: "Spouse",
                newName: "SpouseGrossIncome");

            migrationBuilder.CreateTable(
                name: "AddressDto",
                columns: table => new
                {
                    IdAddress = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDto", x => x.IdAddress);
                });

            migrationBuilder.CreateTable(
                name: "SpousesDto",
                columns: table => new
                {
                    SpouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpouseFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpouseLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpouseDob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpouseAge = table.Column<int>(type: "int", nullable: false),
                    SpouseSsn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpouseIncomeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpouseGrossIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpouseSelfEmploymentComp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpouseYtdIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpouseWagesFederal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SpouseYtdFederal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpousesDto", x => x.SpouseId);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilingStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ssn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddressIdAddress = table.Column<int>(type: "int", nullable: true),
                    PrimaryIncomeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryGrossIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrimarySelfEmploymentComp = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrimaryYtdIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrimaryWagesFederal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrimaryYtdFederal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SpousesSpouseId = table.Column<int>(type: "int", nullable: true),
                    GrossIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FederalTaxWithheld = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StandardDeduction = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EstimatedTaxDue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxableIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SelfEmploymentTax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChildTaxCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AdditionalChildTaxCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EarnedIncomeTaxCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RefundAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_AddressDto_StreetAddressIdAddress",
                        column: x => x.StreetAddressIdAddress,
                        principalTable: "AddressDto",
                        principalColumn: "IdAddress");
                    table.ForeignKey(
                        name: "FK_Client_SpousesDto_SpousesSpouseId",
                        column: x => x.SpousesSpouseId,
                        principalTable: "SpousesDto",
                        principalColumn: "SpouseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_SpousesSpouseId",
                table: "Client",
                column: "SpousesSpouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_StreetAddressIdAddress",
                table: "Client",
                column: "StreetAddressIdAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "AddressDto");

            migrationBuilder.DropTable(
                name: "SpousesDto");

            migrationBuilder.RenameColumn(
                name: "SpouseYtdIncome",
                table: "Spouse",
                newName: "SpouseYTDFederalWithholding");

            migrationBuilder.RenameColumn(
                name: "SpouseYtdFederal",
                table: "Spouse",
                newName: "SpouseYTDEarnings");

            migrationBuilder.RenameColumn(
                name: "SpouseWagesFederal",
                table: "Spouse",
                newName: "SpouseWagesIncome");

            migrationBuilder.RenameColumn(
                name: "SpouseSelfEmploymentComp",
                table: "Spouse",
                newName: "SpouseSelfEmploymentCompensation");

            migrationBuilder.RenameColumn(
                name: "SpouseGrossIncome",
                table: "Spouse",
                newName: "SpouseFederalIncomeTaxWithheld");
        }
    }
}
