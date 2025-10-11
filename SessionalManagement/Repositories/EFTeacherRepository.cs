using Microsoft.EntityFrameworkCore;
using SessionalManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace SessionalManagement.Repositories
{
    public class EFTeacherRepository:ITeacherRepository
    {
        private readonly AppDbContext _context;

        public EFTeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _context.Teachers
                .Include(t => t.TeacherSubjects)       
                .ThenInclude(ts => ts.Subject)         
                .ToList();
        }

        public Teacher GetTeacherById(int id)
        {
            return _context.Teachers
                .Include(t => t.TeacherSubjects)
                .ThenInclude(ts => ts.Subject)
                .FirstOrDefault(t => t.Id == id);
        }

        public Teacher GetTeacherByEmail(string email)
        {
            return _context.Teachers
                .Include(t => t.TeacherSubjects)
                .ThenInclude(ts => ts.Subject)
                .FirstOrDefault(t => t.Email == email);
        }

        public Teacher Insert(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return teacher;
        }

        public Teacher Update(Teacher teacher)
        {
            var existing = _context.Teachers
                .Include(t => t.TeacherSubjects)
                .ThenInclude(ts => ts.Subject)
                .FirstOrDefault(t => t.Id == teacher.Id);

            if (existing != null)
            {
                existing.Name = teacher.Name;
                existing.Email = teacher.Email;
                existing.Password = teacher.Password;
                existing.TeacherSubjects = teacher.TeacherSubjects;
                _context.SaveChanges();
            }

            return existing;
        }

        public void Delete(int id)
        {
            var teacher = _context.Teachers
                .Include(t => t.TeacherSubjects)
                .FirstOrDefault(t => t.Id == id);

            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
            }
        }
        public int GetId()
        {
           int c = _context.Teachers.ToList().Count();
            return c - 1;
        }
    }
}