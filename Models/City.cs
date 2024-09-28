using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace refund.Models
{
    public class City
    {
           [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }
        public int StateId { get; set; }
        public required string Name { get; set; }

        public virtual required State State { get; set; }


    }
}