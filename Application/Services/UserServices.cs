using Application.Managers;
using Entities;
using System.Collections.Generic;

namespace Application.Services
{
    public class UserServices
    {
        private readonly IUserRepository _repository;

       
        public UserServices(IUserRepository repository)
        {
            _repository = repository;
        }

        
        public void AddUser(User user)
        {
            _repository.AddUser(user);
        }

        
        public void RemoveUser(User user)
        {
            _repository.DeleteUser(user.UserId);
        }

       
        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }


        public User AuthenticateUser(string email, string password)
        {
            var user = _repository.GetUserByEmail(email);
            if (user != null && user.Password == password)
            {
                return user; 
            }
            return null; 
        }
    }
}
