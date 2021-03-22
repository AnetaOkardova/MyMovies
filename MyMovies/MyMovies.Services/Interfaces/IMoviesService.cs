using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface IMoviesService
    {
        List<Movie> GetAllMovies();
        List<Movie> GetMoviesByTitle(string title);

        Movie GetMovieById(int id);
        void CreateMovie(Movie movie);
        void Delete(int id);
        void Update(Movie movie);
    }
}
