using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace refund.DTOs
{
    public class SecurityQuestionsDtos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }
        public string? QuestionText { get; set; }
    }
}