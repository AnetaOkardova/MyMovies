using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public StatusModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUSers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public StatusModel SignIn(string username, string password, bool IsPersistent, HttpContext httpContext)
        {
            var response = new StatusModel();
            var user = _userRepository.GetByUsername(username);

            if (user != null && user.Password == password)
            {
                var claims = new List<Claim>()
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Username", user.Username),
                    //new Claim("Address", user.Address),
                    ////new Claim("Email", user.Email),
                    //new Claim("Username", user.Username)
                };
                //create licna karta
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //create user
                var principal = new ClaimsPrincipal(identity);

                var authProps = new AuthenticationProperties() { IsPersistent = IsPersistent };
                
                Task.Run( () => httpContext.SignInAsync(principal, authProps)).GetAwaiter().GetResult();
                
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = $"The username or password is incorrect.";
            }
            return response;
        }

        public void SignOut(HttpContext httpContext)
        {
            Task.Run(() => httpContext.SignOutAsync()).GetAwaiter().GetResult();
        }

        public StatusModel Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
