using SessionalManagement.Models;
using System.Collections.Generic;

namespace SessionalManagement.Repositories
{
    public interface ISubjectRepository
    {
        public IEnumerable<Subject> GetAllSubjects();
        public Subject GetSubjectById(int id);
        public Subject GetSubjectByName(string email);

        public Subject Insert(Subject Subject);

        public Subject Update(Subject Subject);

        public void Delete(int id);
    }
}
