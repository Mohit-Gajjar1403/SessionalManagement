using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SessionalManagement.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Semester Semester { get; set; } // enum

        [Required]
        public ICollection<TeacherSubjects> TeacherSubjects { get; set; } 
    }
}
