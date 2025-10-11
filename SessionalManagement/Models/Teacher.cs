using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SessionalManagement.Models
{
    public class Teacher : User
    {
        public ICollection<TeacherSubjects> TeacherSubjects { get; set; }
    }
}
