using Microsoft.AspNetCore.Http;
using MyMovies.Models;
using MyMovies.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface IAuthService
    {
        List<User> GetAllUSers();
        StatusModel SignIn(string username, string password, bool IsPersistent, HttpContext httpContext);
        User GetUserById(int id);


        void CreateUser(User user);
        StatusModel Delete(int id);
        StatusModel Update(User user);
        void SignOut(HttpContext httpContext);
    }
}
