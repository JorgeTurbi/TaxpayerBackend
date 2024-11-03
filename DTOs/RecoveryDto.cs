using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace refund.DTOs
{
    public class RecoveryDto
    {
        public string? Zipcode { get; set; }
        public string? QuestionText { get; set; }
        public string? Response { get; set; }
    }
}