using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace refund.Models
{
    public class Address
    {
          [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAddress { get; set; }
        public required int TaxplayerId { get; set; }
        public string? StreetAddress { get; set; }=string.Empty;
        public int? CityId { get; set; }
        public  int? StateId { get; set; }
        public  string?  ZipCode { get; set; }=string.Empty;
        public DateTime Created_On { get; set; }

        public required virtual TaxPlayer TaxPlayer {get;set;}
        public   virtual State? State {get;set;}
        public  virtual City? City {get;set;}

    }
}