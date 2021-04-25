using System;
using System.Collections.Generic;
using System.Linq;
using MyMovies.Common.Exceptions;
using MyMovies.Common.Models;
using MyMovies.Common.Services;
using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;

namespace MyMovies.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMovieGenresService _movieGenresService;
        private readonly ILogService _logService;
        private readonly IMoviesRepository _moviesRepository;
        public MoviesService(IMoviesRepository moviesRepository, IUserRepository userRepository, ICommentsRepository commentsRepository, IMovieGenresService movieGenresService, ILogService logService)
        {
            _moviesRepository = moviesRepository;
            _userRepository = userRepository;
            _commentsRepository = commentsRepository;
            _movieGenresService = movieGenresService;
            _logService = logService;
        }

        public List<Movie> GetAllMovies()
        {
            return _moviesRepository.GetAll();
        }
        public Movie GetMovieById(int id)
        {
            var movie = _moviesRepository.GetById(id);
            if (movie == null)
            {
                throw new MoviesException($"There is no movie with ID {id}");
            }

            return movie;
        }
        public List<Movie> GetMoviesWithFilters(string title)
        {
            return _moviesRepository.GetMoviesWithFilters(title);
        }

        public StatusModel CreateMovie(Movie movie)
        {
            var response = new StatusModel();

            if (!_movieGenresService.CheckIfExists(movie.MovieGenreId))
            {
                response.Success = false;
                response.Message = $"There is no movie genre with name {movie.MovieGenre.Name}";
            };

            movie.DateCreated = DateTime.Now;
            _moviesRepository.Add(movie);

            return response;
        }
        public StatusModel Delete(int id, int userId)
        {
            var response = new StatusModel();

            var movie = _moviesRepository.GetById(id);
            if (movie == null)
            {
                response.Success = false;
                response.Message = $"The movie with ID {id} is not found.";
            }
            else
            {
                response.Success = true;
                response.Message = $"The movie with ID {id} has been successfully deleted.";
                var movieComments = _commentsRepository.GetByMovieId(movie.Id);
                if (movieComments.Count != 0)
                {
                    foreach (var comment in movieComments)
                    {
                        _commentsRepository.Delete(comment);
                    }
                }

                _moviesRepository.Delete(movie);
                var logData = new LogData() { Type = LogType.Info, DateCreated = DateTime.Now, Message = $"User with Id {userId} deleted the movie with id {movie.Id} and title {movie.Title}" };
                _logService.Log(logData);
            }
            return response;
        }
        public StatusModel Update(Movie movie, int userId)
        {
            var response = new StatusModel();
            var movieToUpdate = _moviesRepository.GetById(movie.Id);


            if (movieToUpdate == null)
            {
                response.Success = false;
                response.Message = $"The movie with ID {movie.Id} is not found.";
            }
            else
            {
                movieToUpdate.Title = movie.Title;
                movieToUpdate.ImageURL = movie.ImageURL;
                movieToUpdate.Description = movie.Description;
                movieToUpdate.Duration = movie.Duration;
                movieToUpdate.MovieGenreId = movie.MovieGenreId;
                movieToUpdate.DateUpdated = DateTime.Now;

                _moviesRepository.Update(movieToUpdate);

                response.Success = true;
                response.Message = $"The movie with ID {movie.Id} has been successfully updated.";
                var logData = new LogData() { Type = LogType.Info, DateCreated = DateTime.Now, Message = $"User with Id {userId} updated the movie with id {movie.Id} and title {movie.Title}" };
                _logService.Log(logData);
            }
            return response;
        }
        public Movie GetMovieDetails(int id)
        {
            var movie = GetMovieById(id);
            if (movie == null)
            {
                return movie;
            }
            movie.Views++;

            _moviesRepository.Update(movie);
            return movie;
        }

        public List<Movie> GetTopMovies(int count)
        {
            var movies = _moviesRepository.GetTopMovies(count);

            if (movies.Count == 0)
            {
                throw new MoviesException($"There are no movies at this time.");
            }
            return movies;
        }
        public List<Movie> GetMostRecentMovies(int count)
        {
            var movies = _moviesRepository.GetMostRecentMovies(count);

            if (movies.Count == 0)
            {
                throw new MoviesException($"There are no movies at this time.");
            }
            return movies;
        }
    }
}
