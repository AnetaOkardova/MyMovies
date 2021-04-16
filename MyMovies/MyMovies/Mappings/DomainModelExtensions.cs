using MyMovies.Models;
using MyMovies.ViewModels;
using System.Linq;

namespace MyMovies.Mappings
{
    public static class DomainModelExtensions
    {
        public static UpdateMovieModel ToUpdateMovieModel(this Movie movie)
        {
            return new UpdateMovieModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                ImageURL = movie.ImageURL,
                Duration = movie.Duration
            };
        }

        public static MovieOverviewModel ToMovieOverviewModel(this Movie movie)
        {
            return new MovieOverviewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                ImageURL = movie.ImageURL,
                Duration = movie.Duration,
                Views = movie.Views,
                Description = movie.Description
            };
        }
        public static UpdateUserModel ToUpdateUserModel(this User user)
        {
            return new UpdateUserModel()
            {
                Id = user.Id,
                Name = user.Name,
                Lastname = user.Lastname,
                Address = user.Address,
                Email = user.Email,
            };
        }
        public static UserDetailsModel ToUpdateUserDetailsModel(this User user)
        {
            return new UserDetailsModel()
            {
                Id = user.Id,
                Name = user.Name,
                Lastname = user.Lastname,
                Address = user.Address,
                Email = user.Email,
            };
        }

        public static CreateMovieModel ToCreateMovieModel(this Movie movie)
        {
            return new CreateMovieModel()
            {
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                ImageURL = movie.ImageURL,
                Duration = movie.Duration
            };
        }

        public static MovieDetailsModel ToMovieDetailsModel(this Movie movie)
        {
            return new MovieDetailsModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ImageURL = movie.ImageURL,
                Duration = movie.Duration,
                Views = movie.Views,
                Comments = movie.Comments.Select(x => x.ToCommentModel()).ToList()
            };
        }

        public static MovieSidebarModel ToMovieSidebarModel(this Movie movie)
        {
            return new MovieSidebarModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                DateCreated = movie.DateCreated,
                Views = movie.Views,
            };
        }
        public static MovieCommentModel ToCommentModel(this Comment comment)
        {
            return new MovieCommentModel()
            {
                Id = comment.Id,
                Message = comment.Message,
                DateCreated = comment.DateCreated,
                Username = comment.User.Username
            };
        }
        public static UserDetailsModel ToUserDetailsModel(this User user)
        {
            return new UserDetailsModel()
            {
                Id = user.Id,
                Name = user.Name,
                Lastname = user.Lastname,
                Address = user.Address,
                Email = user.Email,
                Username = user.Username,
                Comments = user.Comments.Select(x => x.ToUserCommentModel()).ToList()
            };
        }
        public static UserCommentsModel ToUserCommentModel(this Comment comment)
        {
            return new UserCommentsModel()
            {
                Message = comment.Message,
                DateCreated = comment.DateCreated,
                Username = comment.User.Username
            };
        }
        public static ManageOverviewUsersModel ToManageOverviewUsersModel(this User user)
        {
            return new ManageOverviewUsersModel()
            {
                Id = user.Id,
                Username = user.Username,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
