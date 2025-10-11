using Microsoft.EntityFrameworkCore;
using SessionalManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace SessionalManagement.Repositories
{
    public class EFMarkRepository:IMarkRepository
    {
        private readonly AppDbContext _context;
        private IExamRepository _examRepository;
        private ISubjectRepository _subjectRepository;
        private IStudentRepository _studentRepository;
        public EFMarkRepository(AppDbContext context)
        {
            _context = context;
        }

        public IExamRepository Exam
        {
            get => _examRepository ??= new EFExamRepository(_context);
        }

        public ISubjectRepository Subject
        {
            get => _subjectRepository ??= new EFSubjectRepository(_context);
        }

        public IStudentRepository Student
        {
            get => _studentRepository ??= new EFStudentRepository(_context);
        }

        public IEnumerable<Marks> GetAllMarks()
        {
            return _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .Include(m => m.Exam)
                .ToList();
        }

        public Marks GetMarkById(int subid,int exid,int studid)
        {
            return _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .Include(m => m.Exam)
                .FirstOrDefault(m => m.ExamId == exid && m.SubjectId == subid && m.StudentId == studid);
        }
        public IEnumerable<Marks> GetMarksByStudent(int studentId)
        {
            return _context.Marks
                .Include(m => m.Subject)
                .Include(m => m.Exam)
                .Where(m => m.StudentId == studentId)
                .ToList();
        }

        public Marks Insert(Marks mark)
        {
            _context.Marks.Add(mark);
            _context.SaveChanges();
            return mark;
        }

        public Marks Update(Marks mark)
        {
            var existing = _context.Marks.FirstOrDefault(m => m.ExamId == mark.ExamId&&m.SubjectId==mark.SubjectId&&m.StudentId==mark.StudentId);
            if (existing != null)
            {
                existing.MarksObtained = mark.MarksObtained ;
                existing.ExamId = mark.ExamId;
                existing.SubjectId = mark.SubjectId;
                existing.StudentId = mark.StudentId;
                _context.SaveChanges();
            }
            return existing;
        }

        public void Delete(int exid,int subid,int stuid)
        {
            var mark = _context.Marks.FirstOrDefault(m => m.ExamId == exid&&m.StudentId==stuid&&m.SubjectId==subid);
            if (mark != null)
            {
                _context.Marks.Remove(mark);
                _context.SaveChanges();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}