using System.ComponentModel.DataAnnotations;

namespace SessionalManagement.Models
{
    public class Exam
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } // "Sessional 1", "Sessional 2", "Sessional 3"
        [Required]
        public Semester Semester { get; set; } 
    }

}
