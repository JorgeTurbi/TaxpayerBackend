using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace refund.Migrations
{
    /// <inheritdoc />
    public partial class InitialsCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilingStatus",
                columns: table => new
                {
                    IdFilingStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_On = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilingStatus", x => x.IdFilingStatus);
                });

            migrationBuilder.CreateTable(
                name: "IncomeType",
                columns: table => new
                {
                    IncometypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nameincometype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_On = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeType", x => x.IncometypeId);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "TaxPreparer",
                columns: table => new
                {
                    TaxPreparerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_On = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPreparer", x => x.TaxPreparerId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateTable(
                name: "TaxPlayer",
                columns: table => new
                {
                    TaxplayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFilingStatus = table.Column<int>(type: "int", nullable: false),
                    TaxPreparerId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datebirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SocialSecurity = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncometypeId = table.Column<int>(type: "int", nullable: false),
                    WagesIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FederalIncomeTaxWithheld = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SelfEmploymentCompensation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    YTDEarnings = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    YTDFederalWithholding = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilingStatusIdFilingStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPlayer", x => x.TaxplayerId);
                    table.ForeignKey(
                        name: "FK_TaxPlayer_FilingStatus_FilingStatusIdFilingStatus",
                        column: x => x.FilingStatusIdFilingStatus,
                        principalTable: "FilingStatus",
                        principalColumn: "IdFilingStatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxPlayer_IncomeType_IncometypeId",
                        column: x => x.IncometypeId,
                        principalTable: "IncomeType",
                        principalColumn: "IncometypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxPlayer_TaxPreparer_TaxPreparerId",
                        column: x => x.TaxPreparerId,
                        principalTable: "TaxPreparer",
                        principalColumn: "TaxPreparerId");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    IdAddress = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxplayerId = table.Column<int>(type: "int", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_On = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.IdAddress);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_Address_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId");
                    table.ForeignKey(
                        name: "FK_Address_TaxPlayer_TaxplayerId",
                        column: x => x.TaxplayerId,
                        principalTable: "TaxPlayer",
                        principalColumn: "TaxplayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    DependentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxplayerId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Datebirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_On = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.DependentsId);
                    table.ForeignKey(
                        name: "FK_Dependents_TaxPlayer_TaxplayerId",
                        column: x => x.TaxplayerId,
                        principalTable: "TaxPlayer",
                        principalColumn: "TaxplayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spouse",
                columns: table => new
                {
                    SpouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxplayerId = table.Column<int>(type: "int", nullable: false),
                    SpouseFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpouseLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpouseDatebirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpouseSocialSecurity = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    SpousePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncometypeId = table.Column<int>(type: "int", nullable: false),
                    SpouseWagesIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SpouseFederalIncomeTaxWithheld = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SpouseSelfEmploymentCompensation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SpouseYTDEarnings = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SpouseYTDFederalWithholding = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spouse", x => x.SpouseId);
                    table.ForeignKey(
                        name: "FK_Spouse_IncomeType_IncometypeId",
                        column: x => x.IncometypeId,
                        principalTable: "IncomeType",
                        principalColumn: "IncometypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spouse_TaxPlayer_TaxplayerId",
                        column: x => x.TaxplayerId,
                        principalTable: "TaxPlayer",
                        principalColumn: "TaxplayerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateId",
                table: "Address",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_TaxplayerId",
                table: "Address",
                column: "TaxplayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_TaxplayerId",
                table: "Dependents",
                column: "TaxplayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Spouse_IncometypeId",
                table: "Spouse",
                column: "IncometypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Spouse_TaxplayerId",
                table: "Spouse",
                column: "TaxplayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxPlayer_FilingStatusIdFilingStatus",
                table: "TaxPlayer",
                column: "FilingStatusIdFilingStatus");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPlayer_IncometypeId",
                table: "TaxPlayer",
                column: "IncometypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPlayer_TaxPreparerId",
                table: "TaxPlayer",
                column: "TaxPreparerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "Spouse");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "TaxPlayer");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "FilingStatus");

            migrationBuilder.DropTable(
                name: "IncomeType");

            migrationBuilder.DropTable(
                name: "TaxPreparer");
        }
    }
}
