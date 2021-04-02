using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repository
{
    public class UsersRepository : IUserRepository
    {
        private MyMoviesDbContext _context { get; set; }
        public UsersRepository(MyMoviesDbContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public bool CheckIfExists(string username, string email)
        {
            return _context.Users.Any(x => x.Username == username || x.Email == email);
        }
    }
}
