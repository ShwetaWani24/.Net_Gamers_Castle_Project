using Application.Contexts;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Managers
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

       
        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        
        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

       
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

       
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        
        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
