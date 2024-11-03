using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace refund.DTOs
{
    public class TaxPreparerDto
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int TaxPreparerId { get; set; }
        public required string Username { get; set; }      
        public required string Name { get; set; }
        public string? Brand { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Messages { get; set; }
        public string? Zipcode { get; set; }
      
        // public IFormFile FileImage { get; set; }=null!;

          

    }
}