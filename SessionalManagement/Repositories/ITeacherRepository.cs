using SessionalManagement.Models;
using System.Collections.Generic;

namespace SessionalManagement.Repositories
{
    public interface ITeacherRepository
    {
        public IEnumerable<Teacher> GetAllTeachers();
        public Teacher GetTeacherById(int id);
        public Teacher GetTeacherByEmail(string email);

        public Teacher Insert(Teacher Teacher);

        public Teacher Update(Teacher Teacher);

        public void Delete(int id);
    }
}
