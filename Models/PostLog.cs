using System;
using System.ComponentModel.DataAnnotations;

namespace routine_explorer.Models
{
    public class PostLog
    {
        public bool HasError { get; set; }
        
        public string Message { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime TimeStamp { get; set; }

        public string ToastStyle { get; set; }
    }
}