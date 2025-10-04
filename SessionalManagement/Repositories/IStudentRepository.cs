using SessionalManagement.Models;
using System.Collections.Generic;

namespace SessionalManagement.Repositories
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAllStudents();
        public Student GetStudentById(int id);
        public Student GetStudentByEmail(string email);
        public IEnumerable<Student> GetStudentsBySemester(Semester semester);
        public Student Insert(Student Student);

        public Student Update(Student Student);

        public void Delete(int id);
    }
}
