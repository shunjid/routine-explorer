using System.ComponentModel.DataAnnotations;

namespace routine_explorer.Models
{
    public class Routine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public string CourseCode { get; set; }

        [Required]
        public string Teacher { get; set; } 

        [Required]
        public string DayOfWeek { get; set; }

        [Required]
        public string TimeRange { get; set; }
    }
}