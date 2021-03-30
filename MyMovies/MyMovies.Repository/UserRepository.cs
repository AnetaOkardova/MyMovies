using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repository
{
    public class UserRepository : IUserRepository
    {
        public void Add(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Delete(Movie movie)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
