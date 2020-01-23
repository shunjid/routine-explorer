using System.ComponentModel.DataAnnotations;

namespace routine_explorer.Models
{
    public class VacantRoom
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public string DayOfWeek { get; set; }

        [Required]
        public string TimeRange { get; set; }

        [Required]
        public RoutineFileUploaderStatus Status { get; set; }
    }
}