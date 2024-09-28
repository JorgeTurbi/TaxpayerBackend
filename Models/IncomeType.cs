using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;

namespace refund.Models
{
    public class IncomeType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IncometypeId { get; set; }
        public required string Nameincometype { get; set; }
        public required DateTime Created_On { get; set; }= DateTime.UtcNow;

    


    }
}