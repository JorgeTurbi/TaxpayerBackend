
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace refund.DTOs
{
    public class FilingStatusDto
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFilingStatus { get; set; }
        public string Name { get; set; } = string.Empty;
      
    }
}