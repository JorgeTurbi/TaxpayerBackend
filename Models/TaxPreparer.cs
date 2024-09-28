using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace refund.Models
{
    public class TaxPreparer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int TaxPreparerId { get; set; }
        public required string Username { get; set; }
        public required string Name { get; set; }
        public string? Brand { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public required DateTime Created_On { get; set; } = DateTime.UtcNow;         
        public  DateTime? Updated_On { get; set; }
        public virtual ICollection<TaxPlayer>? TaxPlayers { get; set; }
    }
}