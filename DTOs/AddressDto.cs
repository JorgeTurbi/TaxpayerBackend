using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace refund.DTOs
{
    public class AddressDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAddress { get; set; }
        public string StreetAddress { get; set; }=string.Empty;
        public string City { get; set; }=string.Empty;
        public string State { get; set; }=string.Empty;
        public string Zip { get; set; }=string.Empty;
    }
}