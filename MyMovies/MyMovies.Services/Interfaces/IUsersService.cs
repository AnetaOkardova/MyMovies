using MyMovies.Models;
using MyMovies.Services.DtoModels;
using System.Collections.Generic;

namespace MyMovies.Services.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
        List<User> GetAllUsers();
        StatusModel ToggleAdminRole(int id);
        StatusModel Delete(int id);
    }
}
