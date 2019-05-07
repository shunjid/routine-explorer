using System.ComponentModel.DataAnnotations;

namespace routine_explorer.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required]
        public int UserRating { get; set; }
        
        [Required]
        public string Suggestion { get; set; }
    }
}