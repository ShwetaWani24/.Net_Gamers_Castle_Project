using Entities;
using System.Collections.Generic;

namespace Application.Managers
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByEmail(string email); 
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
