using Microsoft.EntityFrameworkCore;
using SessionalManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace SessionalManagement.Repositories
{
    public class EFStudentRepository: IStudentRepository
    {
        private readonly AppDbContext _context;

        public EFStudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students
                .Include(s => s.Marks)
                    .ThenInclude(m => m.Subject)
                .ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students
                .Include(s => s.Marks)
                .FirstOrDefault(s => s.Id == id);
        }

        public Student GetStudentByEmail(string email)
        {
            return _context.Students
                .Include(s => s.Marks)
                    .ThenInclude(m => m.Subject)
                .Include(s => s.Marks)
                    .ThenInclude(m => m.Exam)
                .FirstOrDefault(s => s.Email == email);
        }

        public IEnumerable<Student> GetStudentsBySemester(Semester semester)
        {
            return _context.Students
                .Include(s => s.Marks)
                .Where(s => s.Semester == semester)
                .ToList();
        }

        public Student Insert(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student Update(Student student)
        {
            var existing = _context.Students
                .Include(s => s.Marks)
                .FirstOrDefault(s => s.Id == student.Id);

            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Email = student.Email;
                existing.Password = student.Password;
                existing.Marks= student.Marks;

                _context.SaveChanges();
            }
            return existing;
        }

        public void Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
