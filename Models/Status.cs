using System.ComponentModel.DataAnnotations;

namespace routine_explorer.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NameOfFilesUploaded { get; set; }

        [Required]
        public string statusOfPublish { get; set; }
    }
}