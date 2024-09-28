
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace refund.Models
{
    public class TaxPlayer
    {
            /*
            
            Pendiente de preguntar por datos del label (Preparadora)
            userId que realizó este registro (Token)

            */

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaxplayerId { get; set; }
        public required int IdFilingStatus { get; set; }
        public int? TaxPreparerId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datebirth { get; set; }
        [MaxLength(length: 9), MinLength(length: 9)]
        public required string SocialSecurity { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; } = string.Empty;
        public int IncometypeId { get; set; }
       
        [DataType(DataType.Currency)]
        public decimal? WagesIncome { get; set; }
        [DataType(DataType.Currency)]
        public decimal? FederalIncomeTaxWithheld { get; set; }
        [DataType(DataType.Currency)]
        public decimal? SelfEmploymentCompensation { get; set; }
        [DataType(DataType.Currency)]
        public decimal? YTDEarnings { get; set; }
        [DataType(DataType.Currency)]
        public decimal? YTDFederalWithholding { get; set; }
        public required bool IsActive { get; set; }
        public required DateTime Created_On { get; set; }


        // Relationship
        public virtual ICollection<Dependents>? Dependents { get; set; }
        public required virtual FilingStatus FilingStatus { get; set; }
        public required virtual IncomeType IncomeType { get; set; }
        public virtual Spouse? Spouse { get; set; }
        public virtual  Address? Address { get; set; }
        public virtual  TaxPreparer? TaxPreparer { get; set; }
    }
}