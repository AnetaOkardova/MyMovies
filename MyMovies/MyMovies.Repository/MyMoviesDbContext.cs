using Microsoft.EntityFrameworkCore;
using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repository
{
    public class MyMoviesDbContext : DbContext
    {
        public MyMoviesDbContext(DbContextOptions<MyMoviesDbContext> options) : base(options)
        {}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        internal void FirstOrDefault()
        {
            throw new NotImplementedException();
        }
    }
}
