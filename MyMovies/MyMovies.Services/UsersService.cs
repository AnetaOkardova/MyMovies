using MyMovies.Common.Exceptions;
using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace MyMovies.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                response.Success = false;
                response.Message = $"There is no user with Id {id}";
            }
            else
            {
                response.Success = true;
                _userRepository.Delete(user);
            }

            return response;
        }

        public List<User> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return users;
        }

        public User GetDetails(string userId)
        {
            return _userRepository.GetById(Convert.ToInt32(userId));
        }

        public User GetUserById(int id)
        {
            var movie = _userRepository.GetById(id);
            if (movie == null)
            {
                throw new MoviesException($"There is no user with ID {id}");
            }

            return movie;
        }

        public StatusModel ToggleAdminRole(int id)
        {
            var response = new StatusModel();
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                response.Success = false;
                response.Message = $"There is no user with Id {id}";
            }
            else
            {
                response.Success = true;
                user.IsAdmin = !user.IsAdmin;
                _userRepository.Update(user);
            }

            return response;
        }

        public StatusModel Update(User user)
        {
            var response = new StatusModel();
            var userToUpdate = _userRepository.GetById(user.Id);


            if (userToUpdate == null)
            {
                response.Success = false;
                response.Message = $"The user with ID {user.Id} is not found.";
            }
            else
            {
                userToUpdate.Name = user.Name;
                userToUpdate.Lastname = user.Lastname;
                userToUpdate.Address = user.Address;
                userToUpdate.Email = user.Email;
                userToUpdate.DateModified = DateTime.Now;

                _userRepository.Update(userToUpdate);

                response.Success = true;
                response.Message = $"The user with ID {user.Id} has been successfully updated.";
            }
            return response;
        }
    }
}
