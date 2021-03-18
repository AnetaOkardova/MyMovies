using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyMovies.Repository
{
    public class MoviesFileRepository : IMoviesRepository
    {
        public List<Movie> Movies { get; set; }
        const string Path = "Movies.txt";

        public MoviesFileRepository()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }
            var result = File.ReadAllText(Path);
            var deserializedList = JsonConvert.DeserializeObject<List<Movie>>(result);
            Movies = deserializedList;
        }
        public List<Movie> GetAll()
        {
            return Movies;
        }

        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x=> x.Id == id);
        }

        public void Add(Movie movie)
        {
            movie.Id = GenerateId();
            Movies.Add(movie);
            SaveChanges();
        }

        private int GenerateId()
        {
            var maxId = 0;
            if (Movies.Any())
            {
                maxId = Movies.Max(x => x.Id);
            }
            return maxId + 1;
        }
        private void SaveChanges()
        {
            var serilized = JsonConvert.SerializeObject(Movies);
            File.WriteAllText(Path, serilized);
        }

        public List<Movie> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
