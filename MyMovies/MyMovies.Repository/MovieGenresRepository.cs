using Microsoft.EntityFrameworkCore;
using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repository
{
    public class MovieGenresRepository : BaseRepository<MovieGenre>, IMovieGenresRepository
    {
        public MovieGenresRepository(MyMoviesDbContext context) : base(context)
        {
        }
        public override List<MovieGenre> GetAll()

        {
            return _context.MovieGenres.Include(x => x.Movies).ToList();
        }
    }
}
