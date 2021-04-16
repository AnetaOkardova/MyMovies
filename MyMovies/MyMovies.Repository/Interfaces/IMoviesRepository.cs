using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repository.Interfaces
{
    public interface IMoviesRepository : IBaseRepository<Movie>
    {
        List<Movie> GetByTitle(string title);
        List<Movie> GetMostRecentMovies(int count);
        List<Movie> GetTopMovies(int count);
    }
}
