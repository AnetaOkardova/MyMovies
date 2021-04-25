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
        List<Movie> GetMoviesWithFilters(string title);
        Movie GetMovieById(int id);
        Movie GetMovieDetails(int id);


        StatusModel CreateMovie(Movie movie);
        StatusModel Delete(int id, int userId);
        StatusModel Update(Movie movie, int userId);
        List<Movie> GetTopMovies(int count);
        List<Movie> GetMostRecentMovies(int count);

    }
}
