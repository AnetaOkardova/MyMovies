using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Services.Interfaces
{
    public interface IMovieGenresService
    {
        List<MovieGenre> GetAll();
        bool CheckIfExists(int movieGenreId);
    }
}
