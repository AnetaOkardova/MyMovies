using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Repository
{
    public class MoviesMemoryRepository : IMoviesRepository
    {
        public List<Movie> _movies { get; set; }
        public MoviesMemoryRepository()
        {
            var movie = new Movie()
            {
                Id = 1,
                Title = "Home alone",
                Description = "Sth",
                Duration = 100,
                ImageURL = "https://m.media-amazon.com/images/M/MV5BMzFkM2YwOTQtYzk2Mi00N2VlLWE3NTItN2YwNDg1YmY0ZDNmXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg",
            };
            var movie2 = new Movie()
            {
                Id = 2,
                Title = "Home alone",
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

        public void Add(Movie movie)
        {
            movie.Id = GenerateId();
            _movies.Add(movie);
        }

        private int GenerateId()
        {
            var maxId = 0;
            if (_movies.Any())
            {
                maxId = _movies.Max(x => x.Id);
            }
            return maxId + 1;
        }

        public List<Movie> GetMoviesWithFilters(string title)
        {
            throw new NotImplementedException();
        }

        public void Delete(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie movie)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetMostRecentMovies(int count)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetTopMovies(int count)
        {
            throw new NotImplementedException();
        }
    }
}
