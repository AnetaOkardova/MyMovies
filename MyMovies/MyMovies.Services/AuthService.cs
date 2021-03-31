using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

        public StatusModel GetUserByUsername(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            var response = new StatusModel();

            if (user != null && user.Password == password)
            {
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = $"The username or password is incorrect.";
            }
            return response;
        }

        public StatusModel Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
