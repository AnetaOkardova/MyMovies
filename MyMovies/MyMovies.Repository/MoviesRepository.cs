using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Repository
{
    public class MoviesRepository
    {
        public List<Movie> _movies { get; set; }
        public MoviesRepository()
        {
            var movie = new Movie()
            {
                Id = 1,
                Title = "Home alone",
                Genre = "Comedy",
                Description = "Sth",
                Duration = 100,
                ImageURL = "https://m.media-amazon.com/images/M/MV5BMzFkM2YwOTQtYzk2Mi00N2VlLWE3NTItN2YwNDg1YmY0ZDNmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
            };
            var movie2 = new Movie()
            {
                Id = 2,
                Title = "Home alone",
                Genre = "Comedy",
                Description = "Sth",
                Duration = 150,
                ImageURL = "https://m.media-amazon.com/images/M/MV5BMzFkM2YwOTQtYzk2Mi00N2VlLWE3NTItN2YwNDg1YmY0ZDNmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
            };
            _movies = new List<Movie> { movie, movie2 };
        }
        public List<Movie> GetAll()
        {
            return _movies;
        }
        public Movie GetById(int id)
        {
            return _movies.FirstOrDefault(x => x.Id == id);
        }
    }
}
