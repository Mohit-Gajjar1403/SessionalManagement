using SessionalManagement.Models;
using System;
using System.Collections.Generic;

namespace SessionalManagement.Repositories
{
    public interface IMarkRepository
    {
        public IExamRepository Exam{ get; }
        public ISubjectRepository Subject { get; }
        public IStudentRepository Student { get; }
        public IEnumerable<Marks> GetAllMarks();
        public Marks GetMarkById(int sbid,int exid,int stid);
        public IEnumerable<Marks> GetMarksByStudent(int studentId);
        public Marks Insert(Marks mark);
        public Marks Update(Marks mark);
        public void Delete(int exid,int sbid,int stid);
        public void Save();
    }
}
