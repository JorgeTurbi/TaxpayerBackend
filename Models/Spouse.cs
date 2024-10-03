using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace refund.Models
{
    public class Spouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpouseId { get; set; }
        public int TaxplayerId { get; set; }
        
        public required string SpouseFirstName { get; set; }
        public required string SpouseLastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime SpouseDatebirth { get; set; }
        [MaxLength(length: 9), MinLength(length: 9)]
        public required string SpouseSocialSecurity { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? SpousePhone { get; set; } = string.Empty;
        [DataType(DataType.EmailAddress)]
        public string? SpouseEmail { get; set; } = string.Empty;
        public int IncometypeId { get; set; }

        [DataType(DataType.Currency)]
        public decimal? SpouseGrossIncome { get; set; }
        [DataType(DataType.Currency)]
        public decimal? SpouseSelfEmploymentComp { get; set; }
        [DataType(DataType.Currency)]
        public decimal? SpouseYtdIncome { get; set; }
        [DataType(DataType.Currency)]
        public decimal? SpouseWagesFederal { get; set; }
         [DataType(DataType.Currency)]
        public decimal? SpouseYtdFederal { get; set; }
    

        
        public virtual required  TaxPlayer TaxPlayer { get; set; }
        public virtual required  IncomeType IncomeType{ get; set; }


    }
}