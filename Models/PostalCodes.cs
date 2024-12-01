using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace refund.Models
{
    public class PostalCodes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
         public int Id { get; set; }
        public string? ZipCode { get; set; }
        public string? PrimaryCity { get; set; }
        public string? States { get; set; }

    }
}