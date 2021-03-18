using System.Collections.Generic;
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
    }
}
