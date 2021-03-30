using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        List<Movie> GetByTitle(string title);

        Movie GetById(int id);
        void Add(Movie movie);
        void Delete(Movie movie);
        void Update(Movie movie);
    }
}
