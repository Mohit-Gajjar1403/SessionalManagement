using Microsoft.EntityFrameworkCore;
using SessionalManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace SessionalManagement.Repositories
    {
        public class EFSubjectRepository: ISubjectRepository
    {
            private readonly AppDbContext _context;

            public EFSubjectRepository(AppDbContext context)
            {
                _context = context;
            }

            public IEnumerable<Subject> GetAllSubjects()
            {
                return _context.Subjects
                    .Include(s => s.TeacherSubjects)
                    .ToList();
            }

            public Subject GetSubjectById(int id)
            {
                return _context.Subjects
                    .Include(s => s.TeacherSubjects)
                    .FirstOrDefault(s => s.Id == id);
            }

            public Subject GetSubjectByName(string name)
            {
                return _context.Subjects
                    .Include(s => s.TeacherSubjects)
                    .FirstOrDefault(s => s.Name == name);
            }

            public Subject Insert(Subject subject)
            {
                _context.Subjects.Add(subject);
                _context.SaveChanges();
                return subject;
            }

            public Subject Update(Subject subject)
            {
                var existing = _context.Subjects
                    .Include(s => s.TeacherSubjects)
                    .FirstOrDefault(s => s.Id == subject.Id);

                if (existing != null)
                {
                    existing.Name = subject.Name;
                    existing.TeacherSubjects = subject.TeacherSubjects;
                    _context.SaveChanges();
                }

                return existing;
            }

            public void Delete(int id)
            {
                var subject = _context.Subjects
                    .Include(s => s.TeacherSubjects)
                    .FirstOrDefault(s => s.Id == id);

                if (subject != null)
                {
                    _context.Subjects.Remove(subject);
                    _context.SaveChanges();
                }
            }
     }
}


