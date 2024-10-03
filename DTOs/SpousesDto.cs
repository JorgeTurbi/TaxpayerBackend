using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace refund.DTOs
{
    public class SpousesDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpouseId { get; set; }
        public string SpouseFirstName { get; set; } = string.Empty;
        public string SpouseLastName { get; set; } = string.Empty;
        public string SpouseDob { get; set; } = string.Empty;
        public int SpouseAge { get; set; }
        public string SpouseSsn { get; set; } = string.Empty;
        public string SpouseIncomeType { get; set; } = string.Empty;
        public decimal SpouseGrossIncome { get; set; }
        public decimal SpouseSelfEmploymentComp { get; set; }
        public decimal SpouseYtdIncome { get; set; }
        public decimal SpouseWagesFederal { get; set; }
        public decimal SpouseYtdFederal { get; set; }
    }
}