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
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieLike> MovieLikes { get; set; }
    }
}
