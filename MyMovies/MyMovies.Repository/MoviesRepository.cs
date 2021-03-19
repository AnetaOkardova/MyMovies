using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private MyMoviesDbContext _context { get; set; }
        public MoviesRepository(MyMoviesDbContext context)
        {
            _context = context;
        }
        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
        public void Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }
        public List<Movie> GetAll()
        {
           return  _context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
          return  _context.Movies.FirstOrDefault(x => x.Id == id);
        }

        public List<Movie> GetByTitle(string title)
        {
            return _context.Movies.Where(x=> x.Title.Contains(title)).ToList();
        }
    }
}
