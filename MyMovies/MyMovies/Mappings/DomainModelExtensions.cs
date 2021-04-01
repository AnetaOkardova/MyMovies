using MyMovies.Models;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Mappings
{
    public static class DomainModelExtensions
    {
        public static UpdateMovieModel ToUpdateMovieModel(this Movie movie)
        {
            return new UpdateMovieModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                ImageURL = movie.ImageURL,
                Duration = movie.Duration
            };
        }
        public static CreateMovieModel ToCreateMovieModel(this Movie movie)
        {
            return new CreateMovieModel()
            {
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                ImageURL = movie.ImageURL,
                Duration = movie.Duration
            };
        }

        public static MovieDetailsModel ToMovieDetailsModel(this Movie movie)
        {
            return new MovieDetailsModel()
            {
                Title = movie.Title,
                Description = movie.Description,
                ImageURL = movie.ImageURL,
                Duration = movie.Duration
            };
        }
        public static UserDetailsModel ToUserDetailsModel(this User user)
        {
            return new UserDetailsModel()
            {
                Name = user.Name,
                Lastname = user.Lastname,
                Address = user.Address,
                Email = user.Email,
                Username = user.Username,
            };
        }
    }
}
