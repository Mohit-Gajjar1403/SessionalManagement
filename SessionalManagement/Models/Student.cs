using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SessionalManagement.Models
{
    public class Student : User
    {
        [Required]
        public Semester Semester { get; set; }

        public ICollection<Marks> Marks { get; set; }
    }
}
