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
       

        public StatusModel SignIn(string username, string password, bool IsPersistent, HttpContext httpContext)
        {
            var response = new StatusModel();
            var user = _userRepository.GetByUsername(username);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                var claims = new List<Claim>()
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Username", user.Username),
                    new Claim("IsAdmin", user.IsAdmin.ToString()),
                    new Claim("Address", user.Address),
                    new Claim("Email", user.Email),
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
        public StatusModel SignUp(User user)
        {
            var response = new StatusModel();
            var exist = _userRepository.CheckIfExists(user.Username, user.Email);
            if(exist)
            {
                response.Success = false;
                response.Message = "This username has alredy been taken. Please try with another username.";
            }
            else
            {
                var newUser = new User()
                {
                    Username = user.Username,
                    Name = user.Name,
                    Lastname = user.Lastname,
                    Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                    Address = user.Address,
                    Email = user.Email,
                    DateCreated = DateTime.Now,
                };
                _userRepository.Add(newUser);
                response.Success = true;
            }
            return response;
        }

        public StatusModel Update(User user)
        {
            throw new NotImplementedException();
        }
        public StatusModel Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
