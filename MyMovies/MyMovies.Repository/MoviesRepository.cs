using Microsoft.EntityFrameworkCore;
using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repository
{
    public class MoviesRepository : BaseRepository<Movie>, IMoviesRepository
    {
        public MoviesRepository(MyMoviesDbContext context) : base (context)
        {
        }
        
        public List<Movie> GetByTitle(string title)
        {
            return _context.Movies.Where(x=> x.Title.Contains(title)).ToList();
        }
        public override Movie GetById(int entityId)
        {
            return _context.Movies.Include(x=>x.Comments).ThenInclude(x => x.User).FirstOrDefault(x => x.Id == entityId);
        }
    }
}
