using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool CheckIfExists(string username, string email);
        User GetByUsername(string username);
    }
}
