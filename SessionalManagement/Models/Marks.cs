namespace SessionalManagement.Models
{
    public class Marks
    {

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public int MarksObtained { get; set; }
    }
}

