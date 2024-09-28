
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace refund.DTOs
{
    public class IncomeTypeDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IncometypeId { get; set; }
        public required string Nameincometype { get; set; }
    
    } 

}