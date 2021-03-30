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
        private IMoviesRepository _moviesRepository { get; set; }
        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public List<Movie> GetAllMovies()
        {
            var movies = _moviesRepository.GetAll();

            if (movies.Count == 0)
            {
                throw new MoviesException("There is no movies at this time");
            }
            return movies;
        }
        public Movie GetMovieById(int id)
        {
            var movie = _moviesRepository.GetById(id);
            if (movie == null)
            {
                throw new MoviesException("There is no movie with such ID");
            }

            return movie;
        }
        public List<Movie> GetMoviesByTitle(string title)
        {
            if (title == null)
            {
                return _moviesRepository.GetAll();
            }
            else
            {
                var movies = _moviesRepository.GetByTitle(title);

                if (movies.Count == 0)
                {
                    throw new MoviesException("There is no movie containing {title} in it's title");
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
    }
}
