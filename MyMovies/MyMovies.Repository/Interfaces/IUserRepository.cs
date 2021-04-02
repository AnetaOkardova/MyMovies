using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Delete(User user);
        void Update(User user);
        User GetByUsername(string username);
        bool CheckIfExists(string username, string email);
    }
}
