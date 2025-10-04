using Microsoft.EntityFrameworkCore;
using SessionalManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace SessionalManagement.Repositories
{
    public class EFExamRepository:IExamRepository
    {
        private readonly AppDbContext _context;

        public EFExamRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Exam> GetAllExams()
        {
            return _context.Exams
                .AsNoTracking() //for read-only data fetching
                .ToList();
        }

        public Exam GetExamById(int id)
        {
            return _context.Exams
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public Exam GetExamBySemester(Semester semester)
        {
            return _context.Exams
                .AsNoTracking()
                .FirstOrDefault(e => e.Semester == semester);
        }

        public Exam Insert(Exam exam)
        {
            _context.Exams.Add(exam);
            _context.SaveChanges();
            return exam;
        }
        public Exam Update(Exam exam)
        {
            var existing = _context.Exams.FirstOrDefault(e => e.Id == exam.Id);
            if (existing != null)
            {
                existing.Name = exam.Name;
                existing.Semester = exam.Semester;
                _context.SaveChanges();
            }
            return existing;
        }
        public void Delete(int id)
        {
            var exam = _context.Exams.FirstOrDefault(e => e.Id == id);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
                _context.SaveChanges();
            }
        }
    }
}
