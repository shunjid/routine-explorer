using System.ComponentModel.DataAnnotations;

namespace routine_explorer.Models
{
    public class CookieSetter
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w.+\-]+@diu.edu.bd$" ,ErrorMessage = "Only DIU Mail (@diu.edu.bd) Is Acceptable")]
        public string CredentialEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string CredentialKey { get; set; }
    }
}