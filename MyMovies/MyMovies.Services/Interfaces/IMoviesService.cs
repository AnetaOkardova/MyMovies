using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface IMoviesService
    {
        List<Movie> GetAllMovies();

        Movie GetMovieById(int id);
        void CreateMovie(Movie movie);
    }
}
