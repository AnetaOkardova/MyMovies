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
        StatusModel SignIn(string username, string password, bool IsPersistent, HttpContext httpContext);
        StatusModel Delete(int id);
        StatusModel Update(User user);
        void SignOut(HttpContext httpContext);
        StatusModel SignUp(User domainModel);
    }
}
