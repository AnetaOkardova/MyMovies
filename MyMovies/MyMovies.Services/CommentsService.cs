using MyMovies.Common.Exceptions;
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

        public StatusModel Delete(int commentId, int userId)
        {
            var response = new StatusModel();

            var comment = _commentsRepository.GetById(commentId);
            if (comment == null)
            {
                response.Success = false;
                response.Message = $"The comment with ID {comment.Id} is not found.";
            }
            else
            {
                if(comment.UserId != userId)
                {
                    response.Success = false;
                    response.Message = $"The comment with ID {comment.Id} is not yours to delete.";
                }
                response.Success = true;
                response.Message = $"The comment with ID {comment.Id} has been successfully deleted.";

                _commentsRepository.Delete(comment);
            }
            return response;
        }

        public Comment GetCommentById(int id)
        {
            var comment = _commentsRepository.GetById(id);
            if (comment == null)
            {
                throw new MoviesException($"There is no comment with ID {id}");
            }

            return comment;
        }

        //public StatusModel Update(Comment comment)
        //{
        //    var response = new StatusModel();
        //    var commentToUpdate = _commentsRepository.GetById(comment.Id);


        //    if (commentToUpdate == null)
        //    {
        //        response.Success = false;
        //        response.Message = $"The comment with ID {comment.Id} is not found.";
        //    }
        //    else
        //    {
        //        commentToUpdate.Message = comment.Message;
        //        commentToUpdate.DateModified = DateTime.Now;

        //        _commentsRepository.Update(commentToUpdate);

        //        response.Success = true;
        //        response.Message = $"The comment with ID {comment.Id} has been successfully updated.";
        //    }
        //    return response;
        //}
    }
}
