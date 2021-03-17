using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyMovies.Repository
{
    public class MoviesSqlRepository : IMoviesRepository
    {
        public void Add(Movie movie)
        {
            using (var cnn = new SqlConnection("Server=(localDb)\\MSSQLLocalDB;Database= MyMoviesSql; Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = @"insert into Movies(Title, Genre, Description, Duration, ImageURL) 
                            values (@Title, @Genre, @Description, @Duration, @ImageURL)";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Genre", movie.Genre);
                cmd.Parameters.AddWithValue("@Description", movie.Description);
                cmd.Parameters.AddWithValue("@Duration", movie.Duration);
                cmd.Parameters.AddWithValue("@ImageURL", movie.ImageURL);

                var reader = cmd.ExecuteNonQuery();

            };
        }

        public List<Movie> GetAll()
        {
            var movies = new List<Movie>();
            using (var cnn = new SqlConnection("Server=(localDb)\\MSSQLLocalDB;Database= MyMoviesSql; Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = "select * from movies";
                var cmd = new SqlCommand(query, cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var movie = new Movie();

                    movie.Id = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.Genre = reader.GetString(2);
                    movie.Description = reader.GetString(3);
                    movie.Duration = reader.GetInt32(4);
                    movie.ImageURL = reader.GetString(5);

                    movies.Add(movie);
                }

                return movies;
            };
        }

        public Movie GetById(int id)
        {
            Movie movie = null;
            using (var cnn = new SqlConnection("Server=(localDb)\\MSSQLLocalDB;Database= MyMoviesSql; Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = $"select * from movies where id = @Id";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Id", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    movie = new Movie();
                    movie.Id = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.Genre = reader.GetString(2);
                    movie.Description = reader.GetString(3);
                    movie.Duration = reader.GetInt32(4);
                    movie.ImageURL = reader.GetString(5);
                }

                return movie;
            }
        }
        public Movie GetByTitle(string title)
        {
            Movie movie = null;
            using (var cnn = new SqlConnection("Server=(localDb)\\MSSQLLocalDB;Database= MyMoviesSql; Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = $"select * from movies where id = @Title";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Title", title);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    movie = new Movie();
                    movie.Id = reader.GetInt32(0);
                    movie.Title = reader.GetString(1);
                    movie.Genre = reader.GetString(2);
                    movie.Description = reader.GetString(3);
                    movie.Duration = reader.GetInt32(4);
                    movie.ImageURL = reader.GetString(5);
                }

                return movie;
            }
        }
    }
}
