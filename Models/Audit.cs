using System;
using System.ComponentModel.DataAnnotations;

namespace routine_explorer.Models
{
    public class Audit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserIP { get; set; }

        [Required]
        public string UserLocation { get; set; }

        [Required]
        public string AreaAccessed { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime ActionDateTime { get; set; }
    }
}