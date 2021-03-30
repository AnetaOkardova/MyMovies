using MyMovies.Models;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Mappings
{
    public static class ViewModelExtensions
    {
        public static Movie ToModel(this UpdateMovieModel movie)
        {
            return new Movie()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                ImageURL = movie.ImageURL,
                Duration = movie.Duration
            };
        }
        public static Movie ToModel(this CreateMovieModel movie)
        {
            return new Movie()
            {
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                ImageURL = movie.ImageURL,
                Duration = movie.Duration
            };
        }

        public static Movie ToModel(this MovieDetailsModel movie)
        {
            return new Movie()
            {
                Title = movie.Title,
                Description = movie.Description,
                ImageURL = movie.ImageURL,
                Duration = movie.Duration
            };
        }
    }
}
