using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace refund.Models
{
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }
        public required string Name { get; set; }
        public Int64 Range_Start { get; set; }
        public Int64 Range_End { get; set; }


        public required ICollection<City> City { get; set; }
    }
}