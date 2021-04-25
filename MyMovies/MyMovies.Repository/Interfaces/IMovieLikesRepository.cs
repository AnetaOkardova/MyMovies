using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repository.Interfaces
{
    public interface IMovieLikesRepository : IBaseRepository<MovieLike>
    {
        MovieLike Get(int movieId, int userId);
    }
}
