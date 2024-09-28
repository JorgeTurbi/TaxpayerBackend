using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace refund.Models
{
    public class Dependents
    {

          [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DependentsId { get; set; }
        public int TaxplayerId { get; set; }
        public int Total { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datebirth { get; set; }
        public DateTime Created_On { get; set; }
        public  required virtual TaxPlayer TaxPlayer { get; set; }

        
    }
}