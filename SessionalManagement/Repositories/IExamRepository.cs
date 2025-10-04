using SessionalManagement.Models;
using System.Collections.Generic;

namespace SessionalManagement.Repositories
{
    public interface IExamRepository
    {
        public IEnumerable<Exam> GetAllExams();
        public Exam GetExamById(int id);
        public Exam GetExamBySemester(Semester semester);

        public Exam Insert(Exam Exam);

        public Exam Update(Exam Exam);

        public void Delete(int id);
    }
}
