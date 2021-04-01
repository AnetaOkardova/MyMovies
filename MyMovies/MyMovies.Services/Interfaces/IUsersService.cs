using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
    }
}
