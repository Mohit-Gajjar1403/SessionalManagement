using SessionalManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace SessionalManagement.Repositories
{
    public class EFUserRepository:IUserRepository
    {
        private readonly AppDbContext _context;
        public EFUserRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            User u=_context.Users.FirstOrDefault(u=>u.Id==id);
            return u;
        }
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User Insert(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        
        public User Update(User user)
        {
            var existing = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                existing.Name = user.Name;
                existing.Email = user.Email;
                existing.Password = user.Password;

                _context.SaveChanges();
            }
            return existing;
        }
        

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
