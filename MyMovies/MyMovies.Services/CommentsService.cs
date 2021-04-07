using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System;

namespace MyMovies.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMoviesService _movieService;

        public CommentsService(ICommentsRepository commentsRepository, IMoviesService movieService)
        {
            _commentsRepository = commentsRepository;
            _movieService = movieService;
        }

        public StatusModel Add(string comment, int movieId, int userId)
        {
            var response = new StatusModel();

            var movie = _movieService.GetMovieById(movieId);

            if(movie == null)
            {
                response.Success = false;
                response.Message = $"There is no movie with Id {movieId}";
            }
            else
            {
                response.Success = true;
                var newComment = new Comment();
                newComment.Message = comment;
                newComment.MovieId = movieId;
                newComment.UserId = userId;
                newComment.DateCreated = DateTime.Now;
                _commentsRepository.Add(newComment);
            }
            return response;
        }
    }
}
