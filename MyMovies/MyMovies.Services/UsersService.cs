using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetDetails(string userId)
        {
            return _userRepository.GetById(Convert.ToInt32(userId));
        }
    }
}
