using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SessionalManagement.Models
{
    public class Teacher : User
    {
        [Required]
        public ICollection<TeacherSubjects> TeacherSubjects { get; set; }
    }
}
