using System.Collections;
using System.Collections.Generic;
using SessionalManagement.Models;
namespace SessionalManagement.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUserById(int id);
        public User GetUserByEmail(string email);

        public User Insert(User user);
        
        public User Update(User user);

        public void Delete(int id);

    }
}
