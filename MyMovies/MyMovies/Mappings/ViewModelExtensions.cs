using MyMovies.Models;
using MyMovies.ViewModels;

namespace MyMovies.Mappings
{
    public static class ViewModelExtensions
    {
        public static Movie ToModel(this UpdateMovieModel movie)
        {
            return new Movie()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                ImageURL = movie.ImageURL,
                Duration = movie.Duration
            };
        }
        public static User ToModel(this UpdateUserModel user)
        {
            return new User()
            {
                Id = user.Id,
                Name = user.Name,
                Lastname = user.Lastname,
                Address = user.Address,
                Email = user.Email,
            };
        }
        public static Movie ToModel(this CreateMovieModel movie)
        {
            return new Movie()
            {
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                ImageURL = movie.ImageURL,
                Duration = movie.Duration
            };
        }

        public static Movie ToModel(this MovieDetailsModel movie)
        {
            return new Movie()
            {
                Title = movie.Title,
                Description = movie.Description,
                ImageURL = movie.ImageURL,
                Duration = movie.Duration
            };
        }
        public static User ToModel(this SignInModel signInModel)
        {
            return new User()
            {
                Username = signInModel.Username,
                Password = signInModel.Password,
            };
        }
        public static User ToModel(this SignUpModel signUpModel)
        {
            return new User()
            {
                Username = signUpModel.Username,
                Password = signUpModel.Password,
                Name = signUpModel.Name,
                Lastname = signUpModel.Lastname,
                Email = signUpModel.Email,
                Address = signUpModel.Address,
            };
        }
        public static User ToModel(this ManageOverviewUsersModel users)
        {
            return new User()
            {
                Id = users.Id,
                Username = users.Username,
                IsAdmin = users.IsAdmin                
            };
        }
    }
}
