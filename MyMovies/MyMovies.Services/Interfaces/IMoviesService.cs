using MyMovies.Models;
using MyMovies.Services.DtoModels;
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
        Movie GetMovieDetails(int id);


        void CreateMovie(Movie movie);
        StatusModel Delete(int id);
        StatusModel Update(Movie movie);
        List<Movie> GetTopMovies(int count);
        List<Movie> GetMostRecentMovies(int count);

    }
}
