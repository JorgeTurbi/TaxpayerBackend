using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace refund.Models
{
    public class User
    {
           [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Code { get; set; }
         public int? Question { get; set; }
        public string? Response { get; set;} 
        public required string Lastlogin { get; set; }= DateTime.UtcNow.ToString();
        
    }

    public class DatetTime
    {
    }
}