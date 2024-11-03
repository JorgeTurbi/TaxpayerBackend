using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace refund.DTOs
{
    public class LoginDtos
    {
      [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Code { get; set; }
        public int? Question { get; set; }=0;
        public string? Response { get; set; }=string.Empty;
        
    }
}