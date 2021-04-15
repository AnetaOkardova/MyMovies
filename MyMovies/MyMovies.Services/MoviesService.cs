using System;
using System.Collections.Generic;
using MyMovies.Common.Exceptions;
using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;

namespace MyMovies.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IUserRepository _userRepository;

        private readonly IMoviesRepository _moviesRepository;
        public MoviesService(IMoviesRepository moviesRepository, IUserRepository userRepository)
        {
            _moviesRepository = moviesRepository;
            _userRepository = userRepository;
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
        public List<Movie> GetMoviesByTitle(string title)
        {
            if (title == null)
            {
                return GetAllMovies();
            }
            else
            {
                var movies = _moviesRepository.GetByTitle(title);

                if (movies.Count == 0)
                {
                    throw new MoviesException($"There is no movie containing {title} in it's title");
                }
                return movies;
            }
        }

        public void CreateMovie(Movie movie)
        {
            _moviesRepository.Add(movie);
        }
        public StatusModel Delete(int id)
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

                _moviesRepository.Delete(movie);
            }
            return response;
        }
        public StatusModel Update(Movie movie)
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
                movieToUpdate.Genre = movie.Genre;
                movieToUpdate.Duration = movie.Duration;
                movieToUpdate.DateUpdated = DateTime.Now;

                _moviesRepository.Update(movieToUpdate);

                response.Success = true;
                response.Message = $"The movie with ID {movie.Id} has been successfully updated.";
            }
            return response;
        }
        public Movie GetMovieDetails(int id)
        {
            var movie = GetMovieById(id);
            if(movie == null)
            {
                return movie;
            }
            movie.Views++;

            _moviesRepository.Update(movie);
            return movie;
        }
    }
}
