using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace refund.DTOs
{
    public class CLientDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }
        public int TaxplayerId { get; set; }=1;
        public required string Username { get; set; }="default";
        public string? FilingStatus { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Dob { get; set; }  // Considerar usar DateTime si se trabajará con fechas
        public string? Ssn { get; set; }
        public AddressDto? StreetAddress { get; set; }  // Puede ser null, así que es mejor usar nullable types
                                                        // public IDepedents Dependents { get; set; }  // Depende si defines la clase IDepedents
        public string? PrimaryIncomeType { get; set; }
        public decimal PrimaryGrossIncome { get; set; }
        public decimal PrimarySelfEmploymentComp { get; set; }
        public decimal PrimaryYtdIncome { get; set; }
        public decimal PrimaryWagesFederal { get; set; }
        public decimal PrimaryYtdFederal { get; set; }
        public SpousesDto? Spouses { get; set; }  // Puede ser null, así que es mejor usar nullable types
        public decimal GrossIncome { get; set; }
        public decimal FederalTaxWithheld { get; set; }
        public decimal StandardDeduction { get; set; }
        public decimal EstimatedTaxDue { get; set; }
        public decimal TaxableIncome { get; set; }
        public decimal SelfEmploymentTax { get; set; }
        public decimal ChildTaxCredit { get; set; }
        public decimal AdditionalChildTaxCredit { get; set; }
        public decimal EarnedIncomeTaxCredit { get; set; }
        public decimal RefundAmount { get; set; }
    }
}