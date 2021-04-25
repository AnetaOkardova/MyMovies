using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repository
{
    public class MovieLikesRepository : BaseRepository<MovieLike>, IMovieLikesRepository
    {
        public MovieLikesRepository(MyMoviesDbContext context) : base(context)
        {
        }

        public MovieLike Get(int movieId, int userId)
        {
            return _context.MovieLikes.FirstOrDefault(x => x.MovieId == movieId && x.UserId == userId);
        }


    }
}
