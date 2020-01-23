using System;
using System.ComponentModel.DataAnnotations;

namespace routine_explorer.Models
{
    public class ApiErrorModel
    {
        public string ErrorMessage { get; set; }
        
        public string StackTrace { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
    }
}