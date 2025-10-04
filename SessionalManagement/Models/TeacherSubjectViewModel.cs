using System.Collections.Generic;

namespace SessionalManagement.Models
{
    public class TeacherSubjectViewModel
    {
        public List<Teacher> Teachers { get; set; }
        public List<Subject> Subjects { get; set; }
        public Teacher? EditTeacher { get; set; }
    }
}
