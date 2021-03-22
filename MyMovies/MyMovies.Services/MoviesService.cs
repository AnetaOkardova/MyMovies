using System.Collections.Generic;
using MyMovies.Common.Exceptions;
using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using MyMovies.Services.Interfaces;

namespace MyMovies.Services
{
    public class MoviesService : IMoviesService
    {
        private IMoviesRepository _moviesRepository { get; set; }
        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        public List<Movie> GetAllMovies()
        {
            return _moviesRepository.GetAll();
        }
        public Movie GetMovieById(int id)
        {
            return _moviesRepository.GetById(id);
        }
        public void CreateMovie(Movie movie)
        {
            _moviesRepository.Add(movie);
        }

        public List<Movie> GetMoviesByTitle(string title)
        {
            if(title == null)
            {
                return _moviesRepository.GetAll();
            }
            else
            {
                return _moviesRepository.GetByTitle(title);
            }
        }

        public void Delete(int id)
        {
            var movie = _moviesRepository.GetById(id);
            if (movie == null)
            {
                throw new MoviesException($"The movie with ID {id} is not found.");
            }
            else
            {
                _moviesRepository.Delete(movie);
            }
        }

        public void Update(Movie movie)
        {
            if (movie == null)
            {
                throw new MoviesException($"The movie with ID {movie.Id} is not found.");
            }
            else
            {
                _moviesRepository.Update(movie);
            }
        }
    }
}
