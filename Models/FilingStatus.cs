using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace refund.Models
{
    public class FilingStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFilingStatus { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Created_On { get; set; } = DateTime.UtcNow;
        public ICollection<TaxPlayer>? TaxPlayer { get; set; }

    }
}